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

namespace XUnitTestProject1
{
    public class CandidaturasControllerTest
    {

        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;

        public CandidaturasControllerTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }
        //Registar
        [Fact]
        public async System.Threading.Tasks.Task Test_Criar()
        {
            Candidatura candidatura = new Candidatura();
            CandidaturasController candidaturasController = new CandidaturasController(_dbContext, null,"123");
            candidatura.Curso = "informática";
            candidatura.Genero = "Masculino";
            candidatura.Localidade = "Lisboa";
            candidatura.Morada = "Setúbal";
            candidatura.Telemovel = "912814511";
            candidatura.ConcursoId = 1;
                var result = await candidaturasController.Create(candidatura);
           

            Assert.IsType<RedirectToActionResult>(result);
        }



    }
}
