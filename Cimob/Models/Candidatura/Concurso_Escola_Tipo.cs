using Cimob.Models.Utilizadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    /// <summary>
    /// Classe que relaciona o concurso entre a tabela Concurso, escola e tipo 
    /// </summary>
    public class Concurso_Escola_Tipo
    {
        /// <summary>
        /// Atributo para classe Escola
        /// </summary>
        public Escola escola { get; set; }
        /// <summary>
        /// Atributo para classe Tipo de User
        /// </summary>
        public TipoDeUser TipoDeUser { get; set; }
        /// <summary>
        /// Atributo para classe Concurso
        /// </summary>
        public Concurso concurso { get; set; }
        /// <summary>
        /// Atributo para classe Tipo Concurso
        /// </summary>
        public TipoConcurso TipoConcurso { get; set; }
    }
}
