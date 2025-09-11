using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Custom_Validations_Prj.Models;


namespace Custom_Validations_Prj.CustomValidations
{
    public class ValidBirthDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime birthDate;
            if (DateTime.TryParse(Convert.ToString(value), out birthDate))
            {
                var age = DateTime.Today.Year - birthDate.Year;
                if (birthDate > DateTime.Today.AddYears(-age)) age--;

                if (age > 21 && age < 25)
                    return ValidationResult.Success;
            }
            return new ValidationResult("Age must be between 22 and 24 years.");
        }
    }

}