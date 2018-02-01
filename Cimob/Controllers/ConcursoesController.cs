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
    public class ConcursoesController : Controller
    {
        private readonly ApplicationDbContext _context;
       
        public ConcursoesController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        

        // GET: Concursoes
        public async Task<IActionResult> Index(int id)
        {
            if (id==0)
            {
                id = 1;
            }
           var concursoAMostrar = (from res in _context.Escola
                                join c in _context.Concurso
                                on res.EscolaId equals c.EscolaID
                                join tp in _context.TipoConcurso
                                on c.TipoConcursoId equals tp.TipoConcursoId
                                join v in _context.TipoDeUser
                                on c.TipoDeUtilizadorId equals v.TipoDeUserId                                
                                select new Concurso_Escola_Tipo { escola = res, concurso = c, TipoDeUser = v, TipoConcurso = tp }).Where(c => c.TipoDeUser.TipoDeUserId.Equals(id));
            ViewBag.Tipo = id;
            if (concursoAMostrar == null)
            {
                return NotFound();
            }
            return View(concursoAMostrar);
        }

        public async Task<IActionResult> PorPais(int id)
        {
            var concursoAMostrar = (from res in _context.Escola
                                    join c in _context.Concurso
                                    on res.EscolaId equals c.EscolaID
                                    join tp in _context.TipoConcurso
                                    on c.TipoConcursoId equals tp.TipoConcursoId
                                    join v in _context.TipoDeUser
                                    on c.TipoDeUtilizadorId equals v.TipoDeUserId
                                    select new Concurso_Escola_Tipo { escola = res, concurso = c, TipoDeUser = v, TipoConcurso = tp }).Where(c => c.TipoDeUser.TipoDeUserId.Equals(id));
            ViewBag.Tipo = id;
            return View(concursoAMostrar);
        }

        public async Task<IActionResult> PorParceria(int id)
        {
            var concursoAMostrar = (from res in _context.Escola
                                    join c in _context.Concurso
                                    on res.EscolaId equals c.EscolaID
                                    join tp in _context.TipoConcurso
                                    on c.TipoConcursoId equals tp.TipoConcursoId
                                    join v in _context.TipoDeUser
                                    on c.TipoDeUtilizadorId equals v.TipoDeUserId
                                    select new Concurso_Escola_Tipo { escola = res, concurso = c, TipoDeUser = v, TipoConcurso = tp }).Where(c => c.TipoDeUser.TipoDeUserId.Equals(id));
            ViewBag.Tipo = id;
            return View(concursoAMostrar);
        }

        public async Task<IActionResult> PorTipo(int id)
        {
            var concursoAMostrar = (from res in _context.Escola
                                    join c in _context.Concurso
                                    on res.EscolaId equals c.EscolaID
                                    join tp in _context.TipoConcurso
                                    on c.TipoConcursoId equals tp.TipoConcursoId
                                    join v in _context.TipoDeUser
                                    on c.TipoDeUtilizadorId equals v.TipoDeUserId
                                    select new Concurso_Escola_Tipo { escola = res, concurso = c, TipoDeUser = v, TipoConcurso = tp }).Where(c => c.TipoDeUser.TipoDeUserId.Equals(id));
            ViewBag.Tipo = id;
            return View(concursoAMostrar);
        }

        public async Task<IActionResult> consultarDetalhe(int id)
        {
           
            var concurso = await _context.Concurso
                .SingleOrDefaultAsync(m => m.ConcursoId == id);
            if (concurso == null)
            {
                return NotFound();
            }

            return View(concurso);            
        }

    }
}
