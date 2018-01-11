﻿using System;
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
            Candidatura candidatura = new Candidatura();
            candidatura.ConcursoId=id;

            string nome = User.Identity.Name;           

            var user = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.UserName.Equals(nome));

            var candidaturas =  _context.Candidatura.Where(c => c.ApplicationUserId.Equals(user.Id));

            if (candidaturas.Count() > 3)
            {
                return RedirectToAction(nameof(MaximumExceeded));
            }
            else
            {
                var concurso = await _context.Concurso
              .SingleOrDefaultAsync(m => m.ConcursoId == id);

                ViewBag.Descricao = concurso.Descricao;
                return View(candidatura);
            }
        }

        // POST: Candidaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Comentarios, ConcursoId")] Candidatura candidatura)
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

        // POST: Candidaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandidaturaId,UserId,DataCandidatura,EstadoCandidaturaId,Comentarios,ConcursoId,ApplicationUserId")] Candidatura candidatura)
        {
            if (id != candidatura.CandidaturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidaturaExists(candidatura.CandidaturaId))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", candidatura.ApplicationUserId);
            ViewData["ConcursoId"] = new SelectList(_context.Concurso, "ConcursoId", "ConcursoId", candidatura.ConcursoId);
            ViewData["EstadoCandidaturaId"] = new SelectList(_context.EstadoCandidatura, "EstadoCandidaturaId", "EstadoCandidaturaId", candidatura.EstadoCandidaturaId);
            return View(candidatura);
        }

        // GET: Candidaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Candidaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidatura = await _context.Candidatura.SingleOrDefaultAsync(m => m.CandidaturaId == id);
            _context.Candidatura.Remove(candidatura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidaturaExists(int id)
        {
            return _context.Candidatura.Any(e => e.CandidaturaId == id);
        }
    }
}