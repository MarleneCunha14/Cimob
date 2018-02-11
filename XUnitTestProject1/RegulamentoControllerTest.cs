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
    public class RegulamentoControllerTest
    {

        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext _dbContext;

        public RegulamentoControllerTest()
            {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }

        
       
    }
}
