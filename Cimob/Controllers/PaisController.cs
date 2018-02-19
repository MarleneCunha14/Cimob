using System;
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
    public class PaisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaisController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Entrevistas/Create
        public async Task<IActionResult> SearchPais(string id)
        {
            var pais = from m in _context.Pais
                            select m;
            if (!String.IsNullOrEmpty(id))
            {
                pais = pais.Where(s => s.NomePais.Contains(id));
            }
            return View(await pais.ToListAsync());
        }

    }
}
