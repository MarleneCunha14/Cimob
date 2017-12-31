using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class Pais
    {
        [Key]
        public int PaisId { get; set; }
        public string NomePais { get; set; }
    }
}
