using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelStates_Prj.Models
{
    public class User
    {
        [Required(ErrorMessage = "FirstName Required")]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "First Name Cannot be more than 20 characters")]
        public string Fname { get; set; }

        [DisplayName("Last Name")]
        public string Lname { get; set; }

        [Display(Name = "Users Age")]
        [Range(21, 45, ErrorMessage = "Age has to be between 21 and 45 only")]
        public int age { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})$",
            ErrorMessage = "Invalid Format")]
        public string email { get; set; }

        // Attribute-based validation
        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string Phone { get; set; }

        //  Attribute-based validation
        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        public string Address { get; set; }

        //  Code-based validation will be applied in the controller
        [Display(Name = "Password")]
        public string Password { get; set; }
    
}
}