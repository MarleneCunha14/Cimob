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
    public class ConcursosControllerTeste
    {

        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;
        public ConcursosControllerTeste()
        {
        optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }
        //Mostrar Concursos Estudante
        [Fact]
        public async System.Threading.Tasks.Task Test_Mostrar_Concursos_Estudantes()
        {
            ConcursoesController concursoes = new ConcursoesController(_dbContext);
           
            var result = await concursoes.Index(1);
            Assert.IsType<ViewResult>(result);
        }
        //Mostrar Concursos Docente
        [Fact]
        public async System.Threading.Tasks.Task Test_Mostrar_Concursos_Docentes()
        {
            ConcursoesController concursoes = new ConcursoesController(_dbContext);

            var result = await concursoes.Index(2);
            Assert.IsType<ViewResult>(result);
        }



    }
}