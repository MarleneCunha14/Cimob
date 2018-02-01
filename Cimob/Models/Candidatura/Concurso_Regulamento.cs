using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class Concurso_Regulamento
    {
        public int Concurso_RegulamentoId { get; set; }
        public int RegulamentoId { get; set; }
        public int ConcursoId { get; set; }
        public virtual Regulamento Regulamento { get; set; }
        public virtual Concurso concurso { get; set; }
    }
}
