using Cimob.Models.Utilizadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class Utilizador_Entrevista
    {
        public Entrevista entrevista { get; set; }
        public ApplicationUser applicationUser { get; set; }
    }
}
