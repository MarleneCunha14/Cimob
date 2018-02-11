using Cimob.Models.Utilizadores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    /// <summary>
    /// Classe relativa à Tabela Entrevista
    /// </summary>
    public class Entrevista
    {
        [Key]
        /// <summary>
        /// Chave primária da Entrevista
        /// </summary>
        public int EntrevistaId { get; set; }
        /// <summary>
        /// Chave Estrangeira para tabela ApplicationUser
        /// </summary>
        public string ApplicationUserId { get; set; }
        /// <summary>
        /// Chave Estrangeira para tabela Candidatura
        /// </summary>
        public int CandidaturaId { get; set; }
        /// <summary>
        /// Atributo para a Data da Entrevista
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        /// <summary>
        /// Atributo para a Hora da Entrevista
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime Hora { get; set; }
        /// <summary>
        /// Atributo para saber se entrevista já foi feita
        /// </summary>
        public bool jaFoiFeita { get; set; }
        /// <summary>
        /// Atributo para saber estado da candidatura
        /// </summary>
        public int EstadoId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Candidatura Candidatura { get; set; }
    }
}
