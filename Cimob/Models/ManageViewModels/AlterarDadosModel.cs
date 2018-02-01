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
        public string Nome { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }

        public int TipoDeUserId { get; set; }
        public int EscolaId { get; set; }
        public int PaisId { get; set; }

    }
}
