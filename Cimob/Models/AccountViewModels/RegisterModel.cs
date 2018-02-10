using Cimob.Models.Candidatura;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Cimob.Models.AccountViewModels;
using Microsoft.AspNetCore.Mvc;
using Cimob.Models.Utilizadores;

namespace Cimob.Models.AccountViewModels
{
    //classe registo
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Escola")]
        public int EscolaId { get; set; }

        [Required]
        [Display(Name = "Pais")]
        public int PaisId { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public int TipoId { get; set; }

        [Key]
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

  /*      [Required]
        [ValidaDataNascimento(ErrorMessage =
            "Deve ter no minimo 17 anos para se poder registar")]
        public DateTime DataNascimento { get; set; }
*/
        public virtual TipoDeUser TipoDeUser { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual Escola Escola { get; set; }
    }
}
