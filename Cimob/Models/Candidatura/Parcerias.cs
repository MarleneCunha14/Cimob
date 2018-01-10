using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{   
    //Parcerias
    public class Parcerias
    {
        [Key]
        public int ParceriasId { get; set; }
        public int PaisId { get; set; }
        public string Nome { get; set; }
        public string url { get; set; }
    }
}
