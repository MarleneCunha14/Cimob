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
    public class EntrevistasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntrevistasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Entrevistas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Entrevista.Include(e => e.Candidatura);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Entrevistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevista = await _context.Entrevista
                .Include(e => e.Candidatura)
                .SingleOrDefaultAsync(m => m.EntrevistaId == id);
            if (entrevista == null)
            {
                return NotFound();
            }

            return View(entrevista);
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
        public async Task<IActionResult> Create([Bind("EstadoId,CandidaturaId,HoraDia")] Entrevista entrevista, int estadoId)
        {

            var candidatura = _context.Candidatura.SingleOrDefaultAsync(m => m.CandidaturaId == entrevista.CandidaturaId);
            candidatura.Result.EstadoCandidaturaId = estadoId;
            _context.Update(candidatura.Result);
            await _context.SaveChangesAsync();

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

        // GET: Entrevistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevista = await _context.Entrevista.SingleOrDefaultAsync(m => m.EntrevistaId == id);
            if (entrevista == null)
            {
                return NotFound();
            }
            ViewData["CandidaturaId"] = new SelectList(_context.Candidatura, "CandidaturaId", "CandidaturaId", entrevista.CandidaturaId);
            return View(entrevista);
        }

        // POST: Entrevistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntrevistaId,ApplicationUserId,CandidaturaId,HoraDia,jaFoiFeita")] Entrevista entrevista)
        {
            if (id != entrevista.EntrevistaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrevista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrevistaExists(entrevista.EntrevistaId))
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
            ViewData["CandidaturaId"] = new SelectList(_context.Candidatura, "CandidaturaId", "CandidaturaId", entrevista.CandidaturaId);
            return View(entrevista);
        }

        // GET: Entrevistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevista = await _context.Entrevista
                .Include(e => e.Candidatura)
                .SingleOrDefaultAsync(m => m.EntrevistaId == id);
            if (entrevista == null)
            {
                return NotFound();
            }

            return View(entrevista);
        }

        // POST: Entrevistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrevista = await _context.Entrevista.SingleOrDefaultAsync(m => m.EntrevistaId == id);
            _context.Entrevista.Remove(entrevista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrevistaExists(int id)
        {
            return _context.Entrevista.Any(e => e.EntrevistaId == id);
        }
    }
}
