using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cimob.Data;
using Cimob.Models.Candidatura;
using Microsoft.AspNetCore.Authorization;
using Cimob.Services;
using Cimob.Models.Utilizadores;
using Microsoft.AspNet.Identity;

namespace Cimob.Controllers
{
    /// <summary>
    /// Controlador que gere a tabela CandidaturAS
    /// </summary>
    public class CandidaturasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Candidatura candidatura;
        private readonly IEmailSender _emailSender;
        public readonly String _userId;
       

        public CandidaturasController(ApplicationDbContext context, IEmailSender emailSender, String userId)
        {
            _context = context;
            _emailSender = emailSender;
            _userId = userId;
        }
        // GET: Candidaturas/Create
        public async Task<IActionResult> Create(int id)
        {
            candidatura = new Candidatura();
            candidatura.ConcursoId=id;
            
          

            return View(candidatura);
            
        }
       
        // POST: Candidaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Curso,Genero,Localidade,Morada,Telemovel, ConcursoId")] Candidatura candidatura)
        {
            candidatura.DataCandidatura = new DateTime();
            candidatura.EstadoCandidaturaId= 1;
            string id;
            if (User==null)
            {
                id = _userId;
            }
            else
            {
                id= User.Identity.Name;
            }
             
            if (string.Equals(id, "", StringComparison.OrdinalIgnoreCase))
            {
                return NotFound();
            }
            
            if (User == null)
            {
                candidatura.UserId = 1;
                candidatura.ApplicationUserId = _userId;
            }
                var concurso = await _context.Concurso
                .SingleOrDefaultAsync(m => m.ConcursoId.Equals(candidatura.ConcursoId));
            if (ModelState.IsValid)
            {
                if (User != null)
                {
                    var user = await _context.ApplicationUser
               .SingleOrDefaultAsync(m => m.UserName.Equals(id));
                    candidatura.UserId = 1;
                    candidatura.ApplicationUserId = user.Id;
                    _context.Add(candidatura);
                    await _context.SaveChangesAsync();
                    await _emailSender.SendEmailAsync(user.Email, " CIMOB - Candidaturas", "Este email serve para informar de que foi feita uma candidatura com o seu email. Esta está disponivel para consulta na sua área de utilizador.");
                    await _emailSender.SendEmailAsync("Cimob_esw@outlook.pt", " CIMOB - Nova Candidatura", "Este email serve para informar de que o utilizador " + user.Nome + " efectuou uma candidatura para o concurso " + candidatura.Concurso.Nome + ".");
                }
                return RedirectToAction("VerCandidaturasPendentes", "Manage", new { area = "" }); ;
            }


            return View(candidatura);
        }
       

        /// <summary>
        /// Metodo que devolve candidatura pendente para o utilizador
        /// </summary>

        public async Task<IActionResult> VerCandidaturasPendentes()
        {
            string id = User.Identity.Name;
            if (string.Equals(id, "", StringComparison.OrdinalIgnoreCase))
            {
                return NotFound();
            }

            var user = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.UserName.Equals(id));
            if (user == null)
            {
                return NotFound();
            }
            var applicationDbContext = _context.Candidatura.Where(c => c.ApplicationUserId.Equals(user.Id));

            var candidatura = await applicationDbContext.ToListAsync();


            var candidaturasPendentes = (from res in _context.Escola
                                         join c in _context.Concurso
                                         on res.EscolaId equals c.EscolaID
                                         join v in _context.Candidatura
                                         on c.ConcursoId equals v.ConcursoId
                                         join e in _context.EstadoCandidatura
                                         on v.EstadoCandidaturaId equals e.EstadoCandidaturaId
                                         select new ProcessoCandidatura { escola = res, candidatura = v, concurso = c, estadoCandidatura = e });
            

            return View(candidaturasPendentes);
        }

        // GET: Utilizadores/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var candidatura = await _context.Candidatura
                .SingleOrDefaultAsync(m => m.CandidaturaId == id);
            var concurso = await _context.Concurso
                .SingleOrDefaultAsync(m => m.ConcursoId == candidatura.ConcursoId);
            ViewBag.Descricao = concurso.Descricao;

            return View(candidatura);
        }

        // POST: Utilizadores/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidatura = await _context.Candidatura
                .SingleOrDefaultAsync(m => m.CandidaturaId == id);
            _context.Candidatura.Remove(candidatura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(VerCandidaturasPendentes));
        }
        /// <summary>
        /// Metodo que devolve todas as candidaturas para o Administrador
        /// </summary>
        public async Task<IActionResult> IndexAdministrador()
    {
            var candidaturasPendentes = (from res in _context.Escola
                                         join c in _context.Concurso
                                         on res.EscolaId equals c.EscolaID
                                         join v in _context.Candidatura
                                         on c.ConcursoId equals v.ConcursoId
                                         join e in _context.EstadoCandidatura
                                         on v.EstadoCandidaturaId equals e.EstadoCandidaturaId
                                         select new ProcessoCandidatura { escola = res, candidatura = v, concurso = c, estadoCandidatura = e });
            return View(candidaturasPendentes);
        }
        /// <summary>
        /// Metodo que devolve detalhe da Candidatura
        /// </summary>
        public async Task<IActionResult> Detalhe(int id)
        {
            var candidaturasPendentes = (from res in _context.Escola
                                         join c in _context.Concurso
                                         on res.EscolaId equals c.EscolaID
                                         join v in _context.Candidatura
                                         on c.ConcursoId equals v.ConcursoId
                                         join e in _context.EstadoCandidatura
                                         on v.EstadoCandidaturaId equals e.EstadoCandidaturaId
                                         select new ProcessoCandidatura { escola = res, candidatura = v, concurso = c, estadoCandidatura = e }).Where(m=> m.candidatura.CandidaturaId.Equals(id));
            var candidatura = await _context.Candidatura
               .SingleOrDefaultAsync(m => m.CandidaturaId == id);

            var user = await _context.ApplicationUser
              .SingleOrDefaultAsync(m => m.Id== candidatura.ApplicationUserId);

            var pais = await _context.Pais
              .SingleOrDefaultAsync(m => m.PaisId == user.PaisId);

            var Escola = await _context.Escola
             .SingleOrDefaultAsync(m => m.EscolaId == user.EscolaId);
            ViewBag.CandidaturaId = candidatura.CandidaturaId;
            ViewBag.NomeAluno = user.Nome;
            ViewBag.Email = user.Email;
            ViewBag.Nacionalidade = pais.NomePais;
            ViewBag.NomeEscola = Escola.Nome;
            return View(candidaturasPendentes.FirstOrDefault());
        }
        /// <summary>
        /// Metodo quealtera o estado da candidatura
        /// </summary>
        public async Task<IActionResult> AlterarEstado(int id)
        {
            ViewBag.CandidaturaId = id;
            var candidatura = await _context.Candidatura
               .SingleOrDefaultAsync(m => m.CandidaturaId == id);           
            ViewData["EstadoCandidaturaId"] = new SelectList(_context.EstadoCandidatura, "EstadoCandidaturaId", "NomeEstado");
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlterarEstado(Candidatura_Estado model, String returnUrl =null )
        {
          

            return RedirectToAction(nameof(CandidaturasController.AlterarEstadoConfirm), "Candidaturas", model);
         }
        /// <summary>
        /// Metodo quealtera o estado da candidatura
        /// </summary>
        public IActionResult AlterarEstadoConfirm(Candidatura_Estado model)
        {
            ViewBag.CandidaturaId = model.CandidaturaId;
            ViewBag.EstadoCandidaturaId = model.EstadoCandidaturaId;
            if (model.EstadoCandidaturaId == 2)
            {
                ViewBag.Estado = "Aceite";
            }
            if (model.EstadoCandidaturaId == 3)
            {
                ViewBag.Estado = "Rejeitado";
            }

            return View(model);
        }
        /// <summary>
        /// Metodo quealtera o estado da candidatura
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlterarEstadoConfirm([Bind("CandidaturaId,EstadoCandidaturaId")] Candidatura_Estado Candidatura_Estado, String returnUrl = null)
        {
            if (Candidatura_Estado.EstadoCandidaturaId==2)
            {
                return RedirectToAction(nameof(EntrevistasController.Create), "Entrevistas", Candidatura_Estado);
            }
            else
            {
                var candidatura = _context.Candidatura.SingleOrDefaultAsync(m => m.CandidaturaId == Candidatura_Estado.CandidaturaId);
                candidatura.Result.EstadoCandidaturaId = Candidatura_Estado.EstadoCandidaturaId;
                _context.Update(candidatura.Result);
                await _context.SaveChangesAsync();

                string nome = User.Identity.Name;

                var user = await _context.ApplicationUser
                    .SingleOrDefaultAsync(m => m.UserName.Equals(nome));
                var concurso = await _context.Concurso
                    .SingleOrDefaultAsync(m => m.ConcursoId.Equals(candidatura.Result.ConcursoId));

                await _emailSender.SendEmailAsync(user.Email, " CIMOB - Candidaturas", "Este email serve para o informar de que a sua candidatura para o concurso "+ concurso.Nome+" foi rejeitada.");
                return RedirectToAction(nameof(CandidaturasController.IndexAdministrador), "Candidaturas");
            }
            
        }
    }

}
