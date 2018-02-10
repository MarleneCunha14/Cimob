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
    public class EscolasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EscolasController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> SearchEscolas(string id)
        {
            var escola = from m in _context.Escola
                             select m;
            if (!String.IsNullOrEmpty(id))
            {
                escola = escola.Where(s => s.Nome.Contains(id));
            }
            return View(await escola.ToListAsync());
        }
    }
}
