using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Custom_Validations_Prj.Models;


namespace Custom_Validations_Prj.CustomValidations
{
    public class ValidJoiningDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime joiningDate)
            {
                return joiningDate <= DateTime.Today;
            }
            return false;
        }
    }
}