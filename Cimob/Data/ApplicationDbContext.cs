using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cimob.Models;
using Cimob.Models.Candidatura;
using Cimob.Models.Utilizadores;
using Cimob.Models.Contactos;
using Cimob.Models.PontosInteresse;

namespace Cimob.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 


        }
       
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<AjudaAutenticacao> AjudaAutenticacao { get; set; }
        public DbSet<TipoDeUser> TipoDeUser { get; set; }
        public DbSet<Candidatura> Candidatura { get; set; }
        public DbSet<Concurso> Concurso { get; set; }
        public DbSet<Regulamento> Regulamento { get; set; }
        public DbSet<EstadoCandidatura> EstadoCandidatura { get; set; }
        public DbSet<Escola> Escola { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Contacto> Contacto { get; set; }
        public DbSet<Concurso_Regulamento> Concurso_Regulamento { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
      
        public DbSet<PontoInteresse> PontoInteresse { get; set; }
        public DbSet<TipoConcurso> TipoConcurso { get;  set; }
    }
}
