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
{/// <summary>
 /// Controlador que gere a tabela AjudaAutenticacao
 /// </summary>
    public class AjudaAutenticacaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AjudaAutenticacaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo que devolve a ajuda para um id
        /// </summary>
        public async Task<IActionResult> Index(int id)
        {
            var ajuda = await _context.AjudaAutenticacao.SingleOrDefaultAsync(m => m.Id.Equals(id));
            if (ajuda == null)
            {
                return NotFound();
            }
            return View(ajuda);
        }

       
       
    }
}
