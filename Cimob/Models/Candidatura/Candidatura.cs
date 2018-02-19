
using Cimob.Models.Utilizadores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    /// <summary>
    /// Classe relativa à Tabela Candidatura
    /// </summary>
    public class Candidatura
    {
        [Key]
        /// <summary>
        /// Chave primária da Candidatura
        /// </summary>
        public int CandidaturaId { get; set; }
        /// <summary>
        /// Chave Estrangeira para a tabela User
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Atributo Data de Candidatura para a tabela Data candidatura
        /// </summary>
        public DateTime DataCandidatura { get; set; }
        /// <summary>
        /// Chave Estrangeira para a tabela EstadoCandidatura
        /// </summary>
        public int EstadoCandidaturaId { get; set; }
        /// <summary>
        /// Chave Estrangeira para a tabela Concurso
        /// </summary>
        public int ConcursoId { get; set; }
        /// <summary>
        /// Chave Estrangeira para a tabela User
        /// </summary>
        public string ApplicationUserId { get; set; }
        /// <summary>
        /// Atributo Genero para a tabela candidatura
        /// </summary>
       [Required]
        public string Genero { get; set; }
        /// <summary>
        /// Atributo Curso para a tabela candidatura
        /// </summary>
        [Required]
        public string Curso { get; set; }
        /// <summary>
        /// Atributo Morada para a tabela candidatura
        /// </summary>
        public string Morada { get; set; }
        /// <summary>
        /// Atributo Localidade para a tabela candidatura
        /// </summary>
        [Required]
        public string Localidade { get; set; }
        /// <summary>
        /// Atributo Telemovel para a tabela candidatura
        /// </summary>
        [Required]
        public string Telemovel { get; set; }

        public virtual Concurso Concurso { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual EstadoCandidatura EstadoCandidatura { get; set; }
    }
}
