using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MvcApplication7.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please give your ID")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid Format")]
        public string id { get; set; }

        [Required(ErrorMessage = "Please give your Name")]
        [RegularExpression(@"^[a-z A-Z.]+$", ErrorMessage = "Use letters only please")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please give your DOB")]
        public string dob { get; set; }

        [Required(ErrorMessage = "Please give your Email")]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "Please give your Gender")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Please give your Dept")]
        public string dept { get; set; }
    }
}