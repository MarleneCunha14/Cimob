using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Contactos
{
    /// <summary>
    /// Classe relativa à Tabela AjudaAutenticacao
    /// </summary>
    public class Contacto
    {
        /// <summary>
        /// Chave Primária
        /// </summary>
        public int Id { get; set; }

        [Required]
        /// <summary>
        /// Atributo Assunto 
        /// </summary>
        public String Assunto { get; set; }

        [Required]
        /// <summary>
        /// Atributo Descriçao 
        /// </summary>
        public String Descriçao { get; set; }

        [Required]
        [EmailAddress]
        /// <summary>
        /// Atributo Email 
        /// </summary>
        public String Email { get; set; }
    }
}
