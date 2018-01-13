using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cimob.Data;
using Cimob.Models.Candidatura;
using System.IO;
using Microsoft.CodeAnalysis;

namespace Cimob.Controllers
{
    public class RegulamentoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegulamentoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Regulamento.ToListAsync());
        }

  

    }
}
