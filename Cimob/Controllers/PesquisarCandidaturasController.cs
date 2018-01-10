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
    public class PesquisarCandidaturasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PesquisarCandidaturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PesquisarCandidaturas
        public async Task<IActionResult> Index(string id)
        {
            var candidatura = from m in _context.Candidatura
                              select m;
            if (!String.IsNullOrEmpty(id))
            {
                candidatura = candidatura.Where(s => s.Nome.Contains(id));
            }
            //return View(await candidatura.ToListAsync());
             return View(await _context.PesquisarCandidatura.ToListAsync());
        }


    }
}
