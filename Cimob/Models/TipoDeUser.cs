using Cimob.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    public class TipoDeUser
    {
        [Key]
        public int TipoDeUserId { get; set; }
        public String nomeTipo { get; set; }
        public virtual List<RegisterModel> RegisterModel { get; set; }
        public virtual List<ApplicationUser> ApplicationUser { get; set; }
    }
}
