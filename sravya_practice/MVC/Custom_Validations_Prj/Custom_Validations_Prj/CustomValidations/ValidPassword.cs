using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Custom_Validations_Prj.CustomValidations
{
    public class ValidPassword : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string password)
            {
                // Must start with uppercase, followed by digit, then 5 characters
                Regex regex = new Regex(@"^[A-Z][0-9].{5}$");
                return regex.IsMatch(password);
            }
            return false;
        }
    }
}