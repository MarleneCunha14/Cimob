using Cimob.Data;
using Cimob.Controllers;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Cimob.Models.Candidatura;
using Microsoft.EntityFrameworkCore;
using Cimob.Models;
using Cimob.Models.Contactos;
using Cimob.Models.PontosInteresse;

namespace XUnitTestProject1
{
    public class PontosInteresseControllerTest
    {
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;
        public PontosInteresseControllerTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }
        //Mostrar Escolas
        [Fact]
        public async System.Threading.Tasks.Task Test_criarContacto()
        {

            PontoInteressesController escola = new PontoInteressesController(_dbContext);
            PontoInteresse ponto = new PontoInteresse();
            ponto.Nome = "Teste";
            ponto.Url = "url";

            var result = await escola.Index(ponto) ;
            Assert.IsType<ViewResult>(result);
        }
        
    }
}