using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class ProcessoCandidatura
    {
        public Candidatura candidatura { get; set; }
        public Escola escola { get; set; }
        public EstadoCandidatura estadoCandidatura { get; set; }
        public Concurso concurso { get; set; }
    }
}
