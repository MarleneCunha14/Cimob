using Cimob.Models.Candidatura;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.PontosInteresse
{
    public class PontoInteresse
    {
        [Key]
        public int Id { get; set; }
        
        public String Nome { get; set; }

        public String Url { get; set; }

        public int ConcursoId { get; set; }

        public virtual Concurso Concurso { get; set; }
    }
}
