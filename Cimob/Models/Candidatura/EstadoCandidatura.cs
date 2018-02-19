using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    /// <summary>
    /// Classe relativa à Tabela EstadoCandidatura
    /// </summary>
    public class EstadoCandidatura
    {
        [Key]
        /// <summary>
        /// Chave primária da EstadoCandidatura
        /// </summary>
        public int EstadoCandidaturaId { get; set; }
        /// <summary>
        /// Atributo nome EstadoCandidatura
        /// </summary>
        public String NomeEstado { get; set; }
    }
}
