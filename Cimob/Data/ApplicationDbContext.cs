using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cimob.Models;
using Cimob.Models.Candidatura;

namespace Cimob.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            this.InsertInitialData();

        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<AjudaAutenticacao> AjudaAutenticacao { get; set; }
       // public DbSet<TipoDeUser> TipoDeUser { get; set; }
        public DbSet<Candidatura> Candidatura { get; set; }
        public DbSet<Concurso> Concurso { get; set; }
        public DbSet<Regulamento> Regulamento { get; set; }
        public DbSet<EstadoCandidatura> EstadoCandidatura { get; set; }
        public DbSet<Escola> Escola { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Parcerias> Parcerias { get; set; }
        public DbSet<PesquisarCandidatura> PesquisarCandidatura { get; set; }








        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


          //  builder.Entity<TipoDeUser>().ToTable("TipoDeUser");
            builder.Entity<Candidatura>().ToTable("Candidatura");
            builder.Entity<Concurso>().ToTable("Concurso");
            builder.Entity<Regulamento>().ToTable("Regulamento");
            builder.Entity<EstadoCandidatura>().ToTable("EstadoCandidatura");
            builder.Entity<Escola>().ToTable("Escola");
            builder.Entity<Pais>().ToTable("Pais");
            builder.Entity<PesquisarCandidatura>().ToTable("PesquisarCandidatura");


        }


        private void InsertInitialData()
        {
            ///////1ST RUN
            /*-------inserts da tabela Frota ou a criação de objeto da tabela--------------------------------------------*/
            if (!this.Users.Any())
            {

                var utilizadores = new ApplicationUser[]
                {

                 new ApplicationUser {
                     Id = "6e8a2399-eba6-477b-8836-91b9f106b378",
                     AccessFailedCount= 0,
                     ConcurrencyStamp= "10f6d9c4-eb68-4fce-a92f-5b26c28ee8cc",
                     Email = "usertest@email.com",
                     EmailConfirmed = false,
                     LockoutEnabled = true,
                     LockoutEnd = null,
                     NormalizedEmail = "USERTEST@EMAIL.COM",
                     NormalizedUserName = "USERTEST@EMAIL.COM",
                     PasswordHash = "AQAAAAEAACcQAAAAEL5vVrMx6dm5ARPpXsqpwxLws0de +S9TdTr8aJ0Ax4inM6d+MwAArRIrygueNiatEg==",
                     PhoneNumber=null,
                     PhoneNumberConfirmed = false,
                     SecurityStamp = "d1de02d6 -5f33-481e-b5ce-34fa65b03fc3",
                     TwoFactorEnabled = false,
                     UserName = "usertest@email.com"  }
                };
                foreach (ApplicationUser au in utilizadores)
                {

                    this.Users.Add(au);
                }
                this.SaveChanges();
            }

            /////2ND RUN

            /*-------inserts da tabela Frota ou a criação de objeto da tabela--------------------------------------------*/
            if (!this.Candidatura.Any())
            {

                var candidatura = new Candidatura[]
                {
                new Candidatura { Nome= "Candidatura Adilson", DataCandidatura= DateTime.Parse("15/08/2017 16:58"),}
                };
       
                this.SaveChanges();
            }

            if (!this.PesquisarCandidatura.Any())
            {

                var pesquisa = new PesquisarCandidatura[]
                {
                new PesquisarCandidatura { Nome= " Adilson", CandidaturaId=1,}
                };

                this.SaveChanges();
            }



        }


      //  public DbSet<Cimob.Models.Parcerias> Parcerias { get; set; }
    }
}
