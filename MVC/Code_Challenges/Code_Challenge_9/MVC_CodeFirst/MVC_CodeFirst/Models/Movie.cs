using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CodeFirst.Models
{
    public class Movie
    {
        [Key]
        public int Mid { get; set; }

        [Required]
        public string Moviename { get; set; }

        [Required]
        public string DirectorName { get; set; }

        [Required]
        public DateTime DateofRelease { get; set; }
    }

}