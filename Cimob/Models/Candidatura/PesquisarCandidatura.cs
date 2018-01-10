using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class PesquisarCandidatura
    {
        [Key]
        public int PesquisarCandidaturaId { get; set; }
        public int CandidaturaId { get; set; }
        public string Nome { get; set; }


    }
}
