using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class Concurso_Documentacao
    {
        public Concurso_Regulamento Concurso_Regulamento { get; set; }
        public Documentacao Documentacao { get; set; }
        public Concurso Concurso { get; set; }
    }
}
