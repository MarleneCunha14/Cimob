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
    public class TipoConcurso
    {
 
    [Key]
        /// <summary>
        /// Chave Primário do Tipo de Concurso
        /// </summary>
        public int TipoConcursoId { get; set; }
        /// <summary>
        /// Atributo nome do Tipo de COncurso
        /// </summary>
        public String Nome { get; set; }
        /// <summary>
        /// Atributo imagem do Tipo de COncurso
        /// </summary>
        public String Imagem { get; set; }
    }
}
