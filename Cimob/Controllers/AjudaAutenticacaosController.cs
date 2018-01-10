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
    public class AjudaAutenticacaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AjudaAutenticacaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AjudaAutenticacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.AjudaAutenticacao.ToListAsync());
        }

        // GET: AjudaAutenticacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ajudaAutenticacao = await _context.AjudaAutenticacao
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ajudaAutenticacao == null)
            {
                return NotFound();
            }

            return View(ajudaAutenticacao);
        }

        // GET: AjudaAutenticacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AjudaAutenticacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] AjudaAutenticacao ajudaAutenticacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ajudaAutenticacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ajudaAutenticacao);
        }

        // GET: AjudaAutenticacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ajudaAutenticacao = await _context.AjudaAutenticacao.SingleOrDefaultAsync(m => m.Id == id);
            if (ajudaAutenticacao == null)
            {
                return NotFound();
            }
            return View(ajudaAutenticacao);
        }

        // POST: AjudaAutenticacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] AjudaAutenticacao ajudaAutenticacao)
        {
            if (id != ajudaAutenticacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ajudaAutenticacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AjudaAutenticacaoExists(ajudaAutenticacao.Id))
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
            return View(ajudaAutenticacao);
        }

        // GET: AjudaAutenticacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ajudaAutenticacao = await _context.AjudaAutenticacao
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ajudaAutenticacao == null)
            {
                return NotFound();
            }

            return View(ajudaAutenticacao);
        }

        // POST: AjudaAutenticacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ajudaAutenticacao = await _context.AjudaAutenticacao.SingleOrDefaultAsync(m => m.Id == id);
            _context.AjudaAutenticacao.Remove(ajudaAutenticacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AjudaAutenticacaoExists(int id)
        {
            return _context.AjudaAutenticacao.Any(e => e.Id == id);
        }
    }
}
