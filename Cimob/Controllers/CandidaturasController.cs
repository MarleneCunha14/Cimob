using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cimob.Data;
using Cimob.Models.Candidatura;

namespace Cimob.Controllers
{
    public class CandidaturasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Candidatura candidatura;


        public CandidaturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Candidaturas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Candidatura.Include(c => c.ApplicationUser).Include(c => c.Concurso).Include(c => c.EstadoCandidatura);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult MaximumExceeded()
        {
            return View();
        }

        public IActionResult already()
        {
            return View();
        }
        // GET: Candidaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidatura
                .Include(c => c.ApplicationUser)
                .Include(c => c.Concurso)
                .Include(c => c.EstadoCandidatura)
                .SingleOrDefaultAsync(m => m.CandidaturaId == id);
            if (candidatura == null)
            {
                return NotFound();
            }

            return View(candidatura);
        }

        // GET: Candidaturas/Create
        public async Task<IActionResult> Create(int id)
        {
            candidatura = new Candidatura();
            candidatura.ConcursoId=id;
            
            string nome = User.Identity.Name;           

            var user = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.UserName.Equals(nome));

            candidatura.ApplicationUserId = user.Id;

            return View(candidatura);
            
        }

        // POST: Candidaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Curso,Genero,Localidade,Telemovel, ConcursoId")] Candidatura candidatura)
        {
            candidatura.DataCandidatura = new DateTime();
            candidatura.EstadoCandidaturaId= 1;
            string id = User.Identity.Name;
            if (string.Equals(id, "", StringComparison.OrdinalIgnoreCase))
            {
                return NotFound();
            }

            var user = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.UserName.Equals(id));
            candidatura.UserId = 1;
            candidatura.ApplicationUserId = user.Id;
            if (ModelState.IsValid)
            {
                _context.Add(candidatura);
                await _context.SaveChangesAsync();
                return RedirectToAction("VerCandidaturasPendentes", "Manage", new { area = "" }); ;
            }


            return View(candidatura);
        }

        // GET: Candidaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidatura.SingleOrDefaultAsync(m => m.CandidaturaId == id);
            if (candidatura == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", candidatura.ApplicationUserId);
            ViewData["ConcursoId"] = new SelectList(_context.Concurso, "ConcursoId", "ConcursoId", candidatura.ConcursoId);
            ViewData["EstadoCandidaturaId"] = new SelectList(_context.EstadoCandidatura, "EstadoCandidaturaId", "EstadoCandidaturaId", candidatura.EstadoCandidaturaId);
            return View(candidatura);
        }

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
    }
}
