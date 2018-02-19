using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Estatística
{
    /// <summary>
    /// Classe relativa à Tabela Estatistica
    /// </summary>
    public class Estatistica
    {
        /// <summary>
        /// Chave Primária
        /// </summary>
        public int Id { get; set; }
    
        /// <summary>
        /// Atributo Assunto 
        /// </summary>
        public String Dados { get; set; }
        
        /// <summary>
        /// Atributo Descriçao 
        /// </summary>
        public String Nome { get; set; }

        /// <summary>
        /// Atributo Email 
        /// </summary>
        public String Descricao { get; set; }
    }
}
