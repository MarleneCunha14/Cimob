using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.AccountViewModels
{
    public class ValidaDataNascimento : ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            DateTime Date = Convert.ToDateTime(value);
            DateTime dtMin = DateTime.UtcNow;
            dtMin = dtMin.AddYears(-17);
            if (Date <= dtMin)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult
                ("Deve ter no minimo 17 anos para se poder registar.");
        }
    }
}