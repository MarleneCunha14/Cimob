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
    public class ManageControllerTest
    {

        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;

        public ManageControllerTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }
        //RegistarApplicationException
        [Fact]
        public async System.Threading.Tasks.Task Test_Mostrar_Estado_Candidatura()
        {           
            ManageController manage = new ManageController(null,null,null,null,null, _dbContext);
            
                
           

            Assert.IsType<ApplicationException>(await manage.VerCandidaturasPendentes());
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_Consultar_Dados()
        {
            Candidatura candidatura = new Candidatura();
            CandidaturasController candidaturasController = new CandidaturasController(_dbContext, null, "123");
            candidatura.Curso = "inform�tica";
            candidatura.Genero = "Masculino";
            candidatura.Localidade = "Lisboa";
            candidatura.Morada = "Set�bal";
            candidatura.Telemovel = "912814511";
            candidatura.ConcursoId = 1;
            var result = await candidaturasController.Create(candidatura);


            Assert.IsType<RedirectToActionResult>(result);
        }


    }
}