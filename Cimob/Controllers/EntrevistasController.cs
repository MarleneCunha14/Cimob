using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cimob.Data;
using Cimob.Models.Candidatura;
using Cimob.Services;

namespace Cimob.Controllers
{
    public class EntrevistasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        public EntrevistasController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        // GET: Entrevistas
        public async Task<IActionResult> Index()
        {
            var entrevistasPendentes = (from e in _context.Entrevista
                                         join a in _context.ApplicationUser
                                         on e.ApplicationUserId equals a.Id
                                         select new Utilizador_Entrevista { entrevista = e, applicationUser = a });


            return View(entrevistasPendentes);
        }

        public async Task<IActionResult> IndexUser()
        {
            string nome = User.Identity.Name;

            var user = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.UserName.Equals(nome));

            var entrevistasPendentes = (from e in _context.Entrevista
                                        join a in _context.ApplicationUser
                                        on e.ApplicationUserId equals a.Id
                                        select new Utilizador_Entrevista { entrevista = e, applicationUser = a }).Where(m=>m.applicationUser.Id.Equals(user.Id));


            return View(entrevistasPendentes);
        }

        // GET: Entrevistas/Create
        public  IActionResult Create(Candidatura_Estado model)
        {
            var entrevista = new Entrevista
            {
                CandidaturaId = model.CandidaturaId,
                EstadoId = model.EstadoCandidaturaId
            };
            return View(entrevista);
        }

        // POST: Entrevistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstadoId,CandidaturaId,Data, Hora")] Entrevista entrevista, int estadoId)
        {           

            var candidatura = _context.Candidatura.SingleOrDefaultAsync(m => m.CandidaturaId == entrevista.CandidaturaId);
            candidatura.Result.EstadoCandidaturaId = estadoId;
            _context.Update(candidatura.Result);
            await _context.SaveChangesAsync();
            var user = _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == candidatura.Result.ApplicationUserId);
            await _emailSender.SendEmailAsync(user.Result.Email, " CIMOB - Candidaturas", "Foi Marcada uma entrevista para o dia "+ entrevista.Data.ToString("dd")+ " de " + entrevista.Data.ToString("MMMM") + " de " + entrevista.Data.ToString("yyyy") + " para a hora " + entrevista.Data.ToString("HH")+":"+entrevista.Data.ToString("mm") + ". Caso não possa comparecer contacte 265 790 159 para nova marcação");
          
            entrevista.jaFoiFeita = false;
            entrevista.ApplicationUserId = candidatura.Result.ApplicationUserId;
            if (ModelState.IsValid)
            {
                _context.Add(entrevista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(entrevista);
        }
    }
}
