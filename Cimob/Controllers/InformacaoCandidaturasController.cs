using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cimob.Data;
using Cimob.Models;

namespace Cimob.Controllers
{
    public class InformacaoCandidaturasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InformacaoCandidaturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InformacaoCandidaturas
        public async Task<IActionResult> Index()
        {
            return View(await _context.InformacaoCandidatura.ToListAsync());
        }

        // GET: InformacaoCandidaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informacaoCandidatura = await _context.InformacaoCandidatura
                .SingleOrDefaultAsync(m => m.InformacaoCandidaturaId == id);
            if (informacaoCandidatura == null)
            {
                return NotFound();
            }

            return View(informacaoCandidatura);
        }

        // GET: InformacaoCandidaturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InformacaoCandidaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InformacaoCandidaturaId,CandidaturaId,descricao")] InformacaoCandidatura informacaoCandidatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(informacaoCandidatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(informacaoCandidatura);
        }

        // GET: InformacaoCandidaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informacaoCandidatura = await _context.InformacaoCandidatura.SingleOrDefaultAsync(m => m.InformacaoCandidaturaId == id);
            if (informacaoCandidatura == null)
            {
                return NotFound();
            }
            return View(informacaoCandidatura);
        }

        // POST: InformacaoCandidaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InformacaoCandidaturaId,CandidaturaId,descricao")] InformacaoCandidatura informacaoCandidatura)
        {
            if (id != informacaoCandidatura.InformacaoCandidaturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(informacaoCandidatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InformacaoCandidaturaExists(informacaoCandidatura.InformacaoCandidaturaId))
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
            return View(informacaoCandidatura);
        }

        // GET: InformacaoCandidaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informacaoCandidatura = await _context.InformacaoCandidatura
                .SingleOrDefaultAsync(m => m.InformacaoCandidaturaId == id);
            if (informacaoCandidatura == null)
            {
                return NotFound();
            }

            return View(informacaoCandidatura);
        }

        // POST: InformacaoCandidaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var informacaoCandidatura = await _context.InformacaoCandidatura.SingleOrDefaultAsync(m => m.InformacaoCandidaturaId == id);
            _context.InformacaoCandidatura.Remove(informacaoCandidatura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InformacaoCandidaturaExists(int id)
        {
            return _context.InformacaoCandidatura.Any(e => e.InformacaoCandidaturaId == id);
        }
    }
}
