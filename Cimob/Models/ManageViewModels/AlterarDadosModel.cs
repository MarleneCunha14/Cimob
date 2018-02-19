using Cimob.Models.Candidatura;
using Cimob.Models.Utilizadores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.ManageViewModels
{
    public class AlterarDadosModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public int EscolaId { get; set; }
        [Required]
        public int PaisId { get; set; }
      
        public virtual Pais Pais { get; set; }
        public virtual Escola Escola { get; set; }
    }
}
