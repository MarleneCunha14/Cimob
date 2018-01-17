using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cimob.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cimob.Controllers
{
    public class MapaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MapaController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {

            ViewData["Id"] = new SelectList(_context.Mapa, "Id", "Adress");
            return View();
        }
    }
}