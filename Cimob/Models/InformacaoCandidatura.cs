using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    public class InformacaoCandidatura
    {   
        [Key]
        public int InformacaoCandidaturaId { get; set; }
        public int CandidaturaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
