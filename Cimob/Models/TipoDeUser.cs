using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.AccountViewModels
{
    public class TipoDeUser
    {
        [Key]
        public int TipoDeUserId { get; set; }
        public String nomeTipo { get; set; }
    }
}
