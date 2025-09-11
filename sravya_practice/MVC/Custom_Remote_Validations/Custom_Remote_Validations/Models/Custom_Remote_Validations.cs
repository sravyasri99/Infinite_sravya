using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Custom_Remote_Validations.Models
{
    public class Custom_Remote_Validations
    {
        public string Name { get; set; }

        [Remote("IsEmailExists","Customer",ErrorMessage = "Email Alredy Exists, ")]
        public string Email { get; set; }
    }
}