using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Candidatura
{
    public class Escola
    {
        [Key]
        public int EscolaId { get; set; }
        public String Nome { get; set; }
        public String Url { get; set; }
        public String Descricao { get; set; }
        public String Imagem { get; set; }
        public String Pais { get; set; }

    }
}
