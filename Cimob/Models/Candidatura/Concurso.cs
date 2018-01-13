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
        public int RegulamentoId { get; set; }
        public String Descricao { get; set; }
        public String Nome { get; set; }
        //Caso no futuro queiramos fazer pesquisa por tipo de utilizador

        public int TipoDeUtilizadorId { get; set; }

        public virtual TipoDeUser TipoDeUser { get; set; }
        public virtual Regulamento Regulamento { get; set; }
        public virtual Escola Escola { get; set; }
    }
}
