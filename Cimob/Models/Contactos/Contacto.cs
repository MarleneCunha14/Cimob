using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.Contactos
{
    //classe contacto
    public class Contacto
    {
     
        public int Id { get; set; }

        [Required]
        public String Assunto { get; set; }

        [Required]
        public String Descriçao { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }
    }
}
