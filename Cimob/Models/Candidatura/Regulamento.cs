using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class Regulamento
    {
        [Key]
        public int RegulamentoId { get; set; }
        public string Descricao { get; set; }
    }
}
