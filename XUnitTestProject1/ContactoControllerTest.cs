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

namespace XUnitTestProject1
{
    public class ContactoControllerTest
    {
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;
        public ContactoControllerTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }
        //Mostrar Escolas
        [Fact]
        public async System.Threading.Tasks.Task Test_criarContacto()
        {

            ContactosController escola = new ContactosController(_dbContext, null);
            Contacto contacto = new Contacto();
            contacto.Id = 1;
            contacto.Assunto = "Teste";
            contacto.Descriçao = "Teste2";
            contacto.Email = "email@email.com";

            var result = await escola.Create(contacto); ;
            Assert.IsType<ViewResult>(result);
        }
        
    }
}