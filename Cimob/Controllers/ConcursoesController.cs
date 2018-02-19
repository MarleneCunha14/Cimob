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
using Microsoft.AspNetCore.Http;

namespace Cimob.Controllers
{
    /// <summary>
    /// Controlador que gere a tabela CandidaturAS
    /// </summary>
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
            if (id == 0)
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
        /// <summary>
        /// Get concursos por Pais
        /// </summary>
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
        /// <summary>
        /// Get concursos por Parceria
        /// </summary>
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
        /// <summary>
        /// Get concursos por Tipo
        /// </summary>
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
        /// <summary>
        /// Get concursos por consultarDetalhe
        /// </summary>
        public async Task<IActionResult> consultarDetalhe(int id)
        {
            if (id==null)
            {
                id = 1;
            }

            ViewBag.Valido = true;
            string nome = User.Identity.Name;
            ViewBag.ConcursoId = id;
            var user = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.UserName.Equals(nome));
            if (user == null)
            {
                ViewBag.Aviso = "Tem de estar logado para se candidatar.";
            }
            var concurso = await _context.Concurso
                .SingleOrDefaultAsync(m => m.ConcursoId == id);

            if (concurso == null)
            {
                return NotFound();
            }

         

            if (user != null)
            {
                var candidatura = await _context.Candidatura
             .SingleOrDefaultAsync(m => m.ApplicationUserId == user.Id);
                if (candidatura!=null)
                {
                    if (candidatura.ConcursoId == id)
                    {
                        ViewBag.Valido = false;
                        ViewBag.Aviso = "Já se candidatou a este concurso.";
                    }
                    if (concurso.TipoDeUtilizadorId != user.TipoDeUserId)
                    {
                        ViewBag.Valido = false;
                        ViewBag.Aviso = "Este concurso não é para o seu tipo de utilizador";
                    }
                }
               
                if (concurso.TipoDeUtilizadorId != user.TipoDeUserId)
                {
                    ViewBag.Valido = false;
                    ViewBag.Aviso = "Este concurso não é para o seu tipo de utilizador";
                }
            }
          
                var tipoConcurso = await _context.TipoConcurso
               .SingleOrDefaultAsync(m => m.TipoConcursoId == concurso.TipoConcursoId);
            if (tipoConcurso == null)
            {
                ViewBag.Imagem = "(Sem Imagem)";
            }
            else
            {
                ViewBag.Imagem = tipoConcurso.Imagem;
            }

            ViewBag.Data = concurso.Prazo.ToString("dd") + " de " + concurso.Prazo.ToString("MMMM") + " de " + concurso.Prazo.ToString("yyyy");
            return View(concurso);
        }

    }
}
