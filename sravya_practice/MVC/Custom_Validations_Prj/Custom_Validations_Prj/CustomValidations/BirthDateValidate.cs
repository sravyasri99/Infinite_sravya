using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Custom_Validations_Prj.Models;
using System.ComponentModel.DataAnnotations

namespace Custom_Validations_Prj.CustomValidations
{
    public class BirthDateValidate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime birthday = (DateTime)value;
            if (birthday.Year < 1996)
                return new ValidationResult("Seems you are a bit old for this job..");
            if (birthday.Year > 2003)
                return new ValidationResult("Seems you are very young for this job..");

        }
    }
}