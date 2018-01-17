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
    public class ConcursoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConcursoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Concursoes
        public async Task<IActionResult> Index()
        {
            string nome = User.Identity.Name;

            var user = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.UserName.Equals(nome));
            if (user == null)
            {
                ViewBag.Tipo = 1;
            }
            else
            {
                ViewBag.Tipo = user.TipoDeUserId;
              
            }
                

            //If null mostra tudo

            
            var candidaturas = _context.Candidatura.Where(c => c.ApplicationUserId.Equals(user.Id));
            ViewBag.candidaturas = candidaturas;
            var applicationDbContext = _context.Concurso.Include(c => c.Escola).Include(c => c.Regulamento);




            var concursosShow = (from res in _context.Escola
                                 join c in _context.Concurso
                                 on res.EscolaId equals c.EscolaID
                                 join v in _context.TipoDeUser
                                 on c.TipoDeUtilizadorId equals v.TipoDeUserId
                                  select new Concurso_Escola_Tipo { escola = res, concurso = c, TipoDeUser=v });







            return View(concursosShow);
        }

        // GET: Concursoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concurso = await _context.Concurso
                .Include(c => c.Escola)
                .Include(c => c.Regulamento)
                .SingleOrDefaultAsync(m => m.ConcursoId == id);
            if (concurso == null)
            {
                return NotFound();
            }

            return View(concurso);
        }

        public async Task<IActionResult> MostrarConcursos()
        {
            return View(await _context.Concurso.ToListAsync());
        }

        // GET: Concursoes/Create
        public IActionResult Create()
        {
            ViewData["EscolaID"] = new SelectList(_context.Escola, "EscolaId", "EscolaId");
            ViewData["RegulamentoId"] = new SelectList(_context.Regulamento, "RegulamentoId", "RegulamentoId");
            return View();
        }

        // POST: Concursoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConcursoId,EscolaID,PaisId,RegulamentoId,Descricao,TipoDeUtilizadorId")] Concurso concurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EscolaID"] = new SelectList(_context.Escola, "EscolaId", "EscolaId", concurso.EscolaID);
            ViewData["RegulamentoId"] = new SelectList(_context.Regulamento, "RegulamentoId", "RegulamentoId", concurso.RegulamentoId);
            return View(concurso);
        }

        // GET: Concursoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concurso = await _context.Concurso.SingleOrDefaultAsync(m => m.ConcursoId == id);
            if (concurso == null)
            {
                return NotFound();
            }
            ViewData["EscolaID"] = new SelectList(_context.Escola, "EscolaId", "EscolaId", concurso.EscolaID);
            ViewData["RegulamentoId"] = new SelectList(_context.Regulamento, "RegulamentoId", "RegulamentoId", concurso.RegulamentoId);
            return View(concurso);
        }

        // POST: Concursoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConcursoId,EscolaID,PaisId,RegulamentoId,Descricao,TipoDeUtilizadorId")] Concurso concurso)
        {
            if (id != concurso.ConcursoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcursoExists(concurso.ConcursoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EscolaID"] = new SelectList(_context.Escola, "EscolaId", "EscolaId", concurso.EscolaID);
            ViewData["RegulamentoId"] = new SelectList(_context.Regulamento, "RegulamentoId", "RegulamentoId", concurso.RegulamentoId);
            return View(concurso);
        }

        // GET: Concursoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concurso = await _context.Concurso
                .Include(c => c.Escola)
                .Include(c => c.Regulamento)
                .SingleOrDefaultAsync(m => m.ConcursoId == id);
            if (concurso == null)
            {
                return NotFound();
            }

            return View(concurso);
        }

        // POST: Concursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concurso = await _context.Concurso.SingleOrDefaultAsync(m => m.ConcursoId == id);
            _context.Concurso.Remove(concurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcursoExists(int id)
        {
            return _context.Concurso.Any(e => e.ConcursoId == id);
        }
    }
}
