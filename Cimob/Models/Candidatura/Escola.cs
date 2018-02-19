using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    /// <summary>
    /// Classe relativa à Tabela Escola
    /// </summary>
    public class Escola
    {
        [Key]
        /// <summary>
        /// Chave primária da Escola
        /// </summary>
        public int EscolaId { get; set; }
        /// <summary>
        /// Atributo para o nome da Escola
        /// </summary>
        public String Nome { get; set; }
        /// <summary>
        /// Atributo para o url da Escola
        /// </summary>
        public String Url { get; set; }
        public String Pais { get; set; }
    }
}
