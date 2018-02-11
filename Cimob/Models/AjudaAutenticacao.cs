using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models

{
    /// <summary>
    /// Classe relativa à Tabela AjudaAutenticacao
    /// </summary>
    public class AjudaAutenticacao
    {
        /// <summary>
        /// Id da ajuda
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Atributo Descricao da Ajuda
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Atributo Controlador da Ajuda
        /// </summary>
        public string Controlador { get; set; }
        /// <summary>
        /// Atributo Metodo da Ajuda
        /// </summary>
        public string Metodo { get; set; }
    }
}
