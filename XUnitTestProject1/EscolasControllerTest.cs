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
    public class EscolasControllerTest
    {
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;
        public EscolasControllerTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }
        //Mostrar Escolas
        [Fact]
        public async System.Threading.Tasks.Task Test_SearchEscolas()
        {

            EscolasController escola = new EscolasController(_dbContext);

            var result = await escola.SearchEscolas("EST");
            Assert.IsType<ViewResult>(result);
        }
        
    }
}