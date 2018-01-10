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
    public class ParceriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParceriasController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> SearchParcerias(string id)
        {
            var parcerias = from m in _context.Parcerias
                             select m;
            if (!String.IsNullOrEmpty(id))
            {
                parcerias = parcerias.Where(s => s.Nome.Contains(id));
            }
            return View(await parcerias.ToListAsync());
        }
    }
}
