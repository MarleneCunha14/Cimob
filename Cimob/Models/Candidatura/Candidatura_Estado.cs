using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    /// <summary>
    /// Classe que relaciona a candidatura com o estado de candidatura 
    /// </summary>
    public class Candidatura_Estado
    {
        /// <summary>
        /// Atributo para a Classe Candidatura
        /// </summary>
        public int CandidaturaId { get; set; }
        /// <summary>
        /// Atributo para a Classe EstadoCandidatura
        /// </summary>
        public int EstadoCandidaturaId { get; set; }
    }
}
