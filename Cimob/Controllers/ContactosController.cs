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
using Cimob.Models.Contactos;

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
                await _emailSender.SendEmailAsync("marlenecunha14@hotmail.com"," CIMOB - Erasmus", "Um utilizador enviou a senguinte mensagem: " + contacto.Descriçao + " Email:" + contacto.Email);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contacto);
        }

       

    }
}
