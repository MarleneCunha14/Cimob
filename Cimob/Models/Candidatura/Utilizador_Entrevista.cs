using Cimob.Models.Utilizadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    /// <summary>
    /// Classe que relaciona o ApplicationUser com a Classe Entrevista
    /// </summary>
    public class Utilizador_Entrevista
    {
        /// <summary>
        /// Atributo para classe Entrevista
        /// </summary>
        public Entrevista entrevista { get; set; }
        /// <summary>
        /// Atributo para classe ApplicationUser
        /// </summary>
        public ApplicationUser applicationUser { get; set; }
    }
}
