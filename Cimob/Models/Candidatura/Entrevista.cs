using Cimob.Models.Utilizadores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class Entrevista
    {
        [Key]
        public int EntrevistaId { get; set; }        
        public string ApplicationUserId { get; set; }
        public int CandidaturaId { get; set; }
        public DateTime HoraDia { get; set; }
        public bool jaFoiFeita { get; set; }
        public int EstadoId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Candidatura Candidatura { get; set; }
    }
}
