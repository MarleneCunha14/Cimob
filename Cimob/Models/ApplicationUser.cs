using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cimob.Models.AccountViewModels;
using Cimob.Models.Candidatura;
using Microsoft.AspNetCore.Identity;

namespace Cimob.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {      
        public TipoDeUser TipoDeUser { get; set; }
        public Pais Pais { get; set;}
        public String numeroEstudante { get; set; }
    }
}
