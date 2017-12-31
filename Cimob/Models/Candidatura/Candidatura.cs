using Cimob.Models.Genericos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class Candidatura
    {
        [Key]
        public int CandidaturaId { get; set; }
        public ApplicationUser User { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCandidatura { get; set; }
        public EstadoCandidatura EstadoCandidatura { get; set; }
    }
}
