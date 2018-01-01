using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cimob.Models;
using Cimob.Models.AccountViewModels;

namespace Cimob.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.InsertInitialData();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Cimob.Models.AjudaAutenticacao> AjudaAutenticacao { get; set; }
        public DbSet<Cimob.Models.TipoDeUser> TipoDeUser { get; set; }

        private void InsertInitialData()
        {
            var tipoDeUser = new TipoDeUser[]
               {
                   new TipoDeUser {TipoDeUserId=1, nomeTipo="Estudante"},
                   new TipoDeUser {TipoDeUserId=2, nomeTipo="Docente"}
               };
            foreach (TipoDeUser t in tipoDeUser)
            {

                this.TipoDeUser.Add(t);
            }
            this.SaveChanges();
        }
    }
}
