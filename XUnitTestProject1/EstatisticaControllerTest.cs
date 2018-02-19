using Cimob.Data;
using Cimob.Controllers;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Cimob.Models.Candidatura;
using Microsoft.EntityFrameworkCore;
using Cimob.Models;
using Cimob.Models.AccountViewModels;
using Cimob.Services;
using Cimob.Models.Estatística;

namespace XUnitTestProject1
{
    public class EstatisticaControllerTest
    {

        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;

        public EstatisticaControllerTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }
        //Registar
        [Fact]
        public async System.Threading.Tasks.Task Test_ConsultarEstatistica()
        {
            EstatisticaController estatistica = new EstatisticaController(_dbContext);
            Estatistica sta = new Estatistica();
            sta.Id = 1;
            var result = await estatistica.Index(sta);
            Assert.IsType<ViewResult>(result);
        }



    }
}
