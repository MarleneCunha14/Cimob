using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class EstadoCandidatura
    {

        public EstadoCandidatura()
        {

        }
        [Key]
        public int CandidaturaId { get; set; }
        public String NomeEstado { get; set; }
        public virtual ICollection<Candidatura> listaCandidatura { get; } = new List<Candidatura>();

    }
}
