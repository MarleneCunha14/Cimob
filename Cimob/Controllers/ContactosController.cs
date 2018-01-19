using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cimob.Data;
using Cimob.Models;
using Cimob.Services;

namespace Cimob.Controllers
{
    public class ContactosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public ContactosController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        // GET: Contactos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacto.ToListAsync());
        }

        // GET: Contactos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // GET: Contactos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contactos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Assunto,Descriçao,Email")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                String descricao = "Um utilizador enviou mensagem com a descrição " +contacto.Descriçao+" Com o senguinte email" + contacto.Email;
                await _emailSender.SendEmail(descricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contacto);
        }

        // GET: Contactos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto.SingleOrDefaultAsync(m => m.Id == id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        // POST: Contactos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Assunto,Descriçao,Email")] Contacto contacto)
        {
            if (id != contacto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.Id))
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
            return View(contacto);
        }

        // GET: Contactos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contacto
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // POST: Contactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contacto = await _context.Contacto.SingleOrDefaultAsync(m => m.Id == id);
            _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactoExists(int id)
        {
            return _context.Contacto.Any(e => e.Id == id);
        }
    }
}
