using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class TipoConcurso
    {
 
    [Key]
    public int TipoConcursoId { get; set; }
    public String Nome { get; set; }
    public String Descricao { get; set; }
    public String Imagem { get; set; }
    }
}
