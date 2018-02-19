using Cimob.Models.Utilizadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    /// <summary>
    /// Classe que relaciona o ApplicationUser entre a tabela candidatura, escola, concurso e estadoCandidatura 
    /// </summary>
    public class ProcessoCandidatura
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Candidatura candidatura { get; set; }
        public Escola escola { get; set; }
        public EstadoCandidatura estadoCandidatura { get; set; }
        public Concurso concurso { get; set; }
    }
}
