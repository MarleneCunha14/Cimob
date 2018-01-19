using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cimob.Data;
using Cimob.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            ViewData["url"] = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3121.519727241496!2d-8.841459985258778!3d38.52178612660281!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd194283b59dab81%3A0x22c02723c8bcfb5d!2sEscola%20Superior%20de%20Tecnologia%20de%20Set%C3%BAbal-IPS%2C%20Set%C3%BAbal!5e0!3m2!1spt-PT!2spt!4v1516305459169";
            return View();
        }

        

    }
}