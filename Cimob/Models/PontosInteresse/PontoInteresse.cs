using Cimob.Models.Candidatura;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.PontosInteresse
{
    /// <summary>
    /// Classe relativa à Tabela Ponto de Interesse
    /// </summary>
    public class PontoInteresse
    {
        [Key]
        /// <summary>
        /// Chave Primário do Ponto de Interesse
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Atributo do nome do Pono de Interesse
        /// </summary>
        public String Nome { get; set; }
        /// <summary>
        /// Atributo do Url
        /// </summary>
        public String Url { get; set; }
    }
}
