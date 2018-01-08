using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cimob.Data;
using Cimob.Models;
using Cimob.Models.Candidatura;

namespace TopCar.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
           /* if (  !context.TipoDeUser.Any())
            {
                // Adicionar Marcas para testes
                context.TipoDeUser.Add(new TipoDeUser { TipoDeUserId = 123, nomeTipo = "Estudante" });
                context.TipoDeUser.Add(new TipoDeUser { TipoDeUserId = 211, nomeTipo = "Docente" });
                context.SaveChanges();
                //antes de se usar as FK das marcas na adicão de carros, 
                //tem que se chamar SaveChanges, ou daria um "FK error"
            }*/
            if ( /*NOT*/ !context.Pais.Any())
            {
                // Adicionar Marcas para testes
                context.Pais.Add(new Pais { PaisId = 1, NomePais = "Estudante" });
                context.Pais.Add(new Pais { PaisId = 2, NomePais = "Docente" });
                context.SaveChanges();
                //antes de se usar as FK das marcas na adicão de carros, 
                //tem que se chamar SaveChanges, ou daria um "FK error"
            }

        }
    }
}
