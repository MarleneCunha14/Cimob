using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class Concurso_Bolsa
    {
        [Key]
        public int Concurso_BolsaId { get; set; }
        public int DocumentacaoId { get; set; }
        public int ConcursoId { get; set; }
        public virtual Documentacao Documentacao { get; set; }
        public virtual Concurso Concurso { get; set; }
    }
}
