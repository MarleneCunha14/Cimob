using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Genericos
{
    public class EstadoCandidatura
    {
        [Key]
        public int CandidaturaId { get; set; }
        public String NomeEstado { get; set; }
    }
}
