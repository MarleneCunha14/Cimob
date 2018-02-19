using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cimob.Data;
using Cimob.Models;
using Cimob.Models.Estatística;

namespace Cimob.Controllers
{/// <summary>
 /// Controlador que gere a tabela AjudaAutenticacao
 /// </summary>
    public class EstatisticaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstatisticaController(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {
            var estatistica = await _context.Estatistica.SingleOrDefaultAsync(c => c.Id.Equals(1));
            if (estatistica == null)
            {
                return NotFound();
            }
            ViewBag.Estatisticas = new SelectList(_context.Estatistica, "Id", "Nome");
            return View(estatistica);
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("Id")] Estatistica estistica)
        {
            var estatistica = await _context.Estatistica.SingleOrDefaultAsync(c => c.Id.Equals(estistica.Id));
            
            ViewBag.Estatisticas = new SelectList(_context.Estatistica, "Id", "Nome");
            return View(estatistica);
        }



    }
}
