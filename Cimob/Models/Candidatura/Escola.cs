using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class Escola
    {
        [Key]
        public int EscolaId { get; set; }
        public string NomeEscola { get; set; }
    }
}
