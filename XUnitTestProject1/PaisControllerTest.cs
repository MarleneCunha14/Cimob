using Cimob.Data;
using Cimob.Controllers;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Cimob.Models.Candidatura;
using Microsoft.EntityFrameworkCore;
using Cimob.Models;


namespace XUnitTestCimob
{
    public class PaisControllerTest
    {
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;
        public PaisControllerTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }
        [Fact]
        public async System.Threading.Tasks.Task Test_MostrarPais()
        {

            PaisController pais = new PaisController(_dbContext);

            var result = await pais.SearchPais("Portugal");
            Assert.IsType<ViewResult>(result);
        }
    }
}