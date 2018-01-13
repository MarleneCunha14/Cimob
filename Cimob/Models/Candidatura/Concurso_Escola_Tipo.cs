using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class Concurso_Escola_Tipo
    {
        public Escola escola { get; set; }
        public TipoDeUser TipoDeUser { get; set; }
        public Concurso concurso { get; set; }
    }
}
