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
        public Escola Escola { get; set; }
        public Pais Pais { get; set; }
        public String TipoCandidatura { get; set; }
        public Regulamento Regulamento { get; set; }
        public String Descricao { get; set; }
        //Caso no futuro queiramos fazer pesquisa por tipo de utilizador
        
        public String TipoDeUtilizador { get; set; }
    }
}
