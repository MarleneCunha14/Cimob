using Cimob.Models.Utilizadores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{ /// <summary>
  /// Classe relativa à Tabela Concurso
  /// </summary>
    public class Concurso
    {
        [Key]
        /// <summary>
        /// Chave primária do Concurso
        /// </summary>
        public int ConcursoId { get; set; }
        /// <summary>
        /// Id e chave Estrangeira para a tabela Escola
        /// </summary>
        public int EscolaID { get; set; }
        /// <summary>
        /// Id e chave Estrangeira para a tabela Pais
        /// </summary>
        public int PaisId { get; set; }
        /// <summary>
        /// Atributos descricao do Concurso
        /// </summary>
        public String Descricao { get; set; }
        /// <summary>
        /// Atributos Nome do Concurso
        /// </summary>
        public String Nome { get; set; }
        /// <summary>
        /// Atributos Prazo do Concurso
        /// </summary>
        public DateTime Prazo { get; set; }
        /// <summary>
        /// Id e chave Estrangeira para a tabela Tipo de Utilizador
        /// </summary>
        public int TipoDeUtilizadorId { get; set; }
        /// <summary>
        /// Id e chave Estrangeira para a tabela Tipo de Concurso
        /// </summary>
        public int TipoConcursoId { get; set; }

        public virtual TipoDeUser TipoDeUser { get; set; }
        public virtual Escola Escola { get; set; }
        public virtual TipoConcurso TipoConcurso { get; set; }
    }
}
