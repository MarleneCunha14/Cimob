using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    /// <summary>
    /// Classe relativa à Tabela Pais
    /// </summary>
    public class Pais
    {
        [Key]
        /// <summary>
        /// Chave primária do Pais
        /// </summary>
        public int PaisId { get; set; }
        /// <summary>
        /// Atributo do Nome do Pais
        /// </summary>
        public string NomePais { get; set; }
    }
}
