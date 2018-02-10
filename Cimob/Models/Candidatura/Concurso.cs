using Cimob.Models.Utilizadores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class Concurso
    {
        [Key]
        public int ConcursoId { get; set; }
        public int EscolaID { get; set; }
        public int PaisId { get; set; }
        public String Descricao { get; set; }
        public String Nome { get; set; }
        public DateTime Prazo { get; set; }

        public int TipoDeUtilizadorId { get; set; }
        public int TipoConcursoId { get; set; }

        public virtual TipoDeUser TipoDeUser { get; set; }
        public virtual Escola Escola { get; set; }
        public virtual TipoConcurso TipoConcurso { get; set; }
    }
}
