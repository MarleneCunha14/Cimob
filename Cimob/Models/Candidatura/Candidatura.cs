
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
        public int UserId { get; set; }
        public DateTime DataCandidatura { get; set; }
        public int EstadoCandidaturaId { get; set; }
        public String Comentarios { get; set; }
        public int ConcursoId { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual Concurso Concurso { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual EstadoCandidatura EstadoCandidatura { get; set; }
    }
}
