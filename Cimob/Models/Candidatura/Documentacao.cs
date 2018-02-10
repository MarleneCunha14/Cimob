using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class Documentacao
    {
        [Key]
        public int DocumentoId { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public string Descricao { get; set; }
    }
}
