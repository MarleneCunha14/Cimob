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
    public class PontoInteressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PontoInteressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PontoInteresses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _context.PontoInteresse.SingleOrDefaultAsync(c => c.Id.Equals(1));
            ViewBag.Pontos = new SelectList(_context.PontoInteresse, "Id", "Nome");
            ViewBag.url = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3121.519727241496!2d-8.841459985258778!3d38.52178612660281!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd194283b59dab81%3A0x22c02723c8bcfb5d!2sEscola+Superior+de+Tecnologia+de+Set%C3%BAbal-IPS%2C+Set%C3%BAbal!5e0!3m2!1spt-PT!2spt!4v1516991825445";
            return View(applicationDbContext);
        }

        public async Task<IActionResult> ChooseItem([Bind("Id")] PontoInteresse ponto)
        {
            var pontos = await _context.PontoInteresse.SingleOrDefaultAsync(c => c.Id.Equals(ponto.Id));
          
            ViewBag.Pontos = new SelectList(_context.PontoInteresse, "Id", "Nome");
            ViewBag.url = pontos.Url;
            return View(pontos);
        }

    }
}
