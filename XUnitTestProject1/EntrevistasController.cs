using Cimob.Data;
using Cimob.Controllers;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Cimob.Models.Candidatura;
using Microsoft.EntityFrameworkCore;
using Cimob.Models;

namespace XUnitTestProject1
{
    public class EntrevistasControllerTest
    {
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;
        public EntrevistasControllerTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }
        //Mostrar Entrevistas 2.5 Entrevista entrevista
        [Fact]
        public async System.Threading.Tasks.Task Test_EntrevistasPendentes()
        {

            EntrevistasController entrevistas = new EntrevistasController(_dbContext, null);

            var result = await entrevistas.Index();
            Assert.IsType<ViewResult>(result);
        }

        //Mostrar Entrevistas 2.5 Entrevista entrevista
        [Fact]
        public async System.Threading.Tasks.Task Test_EntrevistasPendentesAlunos()
        {

            EntrevistasController entrevistas = new EntrevistasController(_dbContext, null);

            var result = await entrevistas.IndexUser();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_CriarEntrevista()
        {

            EntrevistasController entrevistas = new EntrevistasController(_dbContext, null);
            Entrevista entrevista = new Entrevista();
            entrevista.ApplicationUserId = "123";
            entrevista.CandidaturaId = 1;
            entrevista.Data = new DateTime();
            entrevista.EstadoId = 1;
            entrevista.Hora = new DateTime(); ;
            entrevista.jaFoiFeita = true;
           
            var result = await entrevistas.Create(entrevista, 1);
            Assert.IsType<ViewResult>(result);
        }

    }
}