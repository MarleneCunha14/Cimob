using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cimob.Models.AccountViewModels;
using Cimob.Models.Candidatura;
using Microsoft.AspNetCore.Identity;

namespace Cimob.Models.Utilizadores
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {      
        public int TipoDeUserId { get; set; }
        public int PaisId { get; set; }
        public int EscolaId { get; set; }
        public string Nome { get; set; }
        public bool isAdministrador { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual TipoDeUser TipoDeUser { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual Escola Escola { get; set; }
        
    }
}
