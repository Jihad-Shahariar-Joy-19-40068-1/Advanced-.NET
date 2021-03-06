//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Patient.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Registration
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        [MaxLength(50, ErrorMessage = "Name length must be less than 50 Characters")]
        [MinLength(3, ErrorMessage = "Name length must not be less than 3 Characters")]
        [RegularExpression(@"^[a-z A-Z.]+$", ErrorMessage = "Use Letters and spaces only please")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your Age")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid Format (Numbers Only)")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please choose your Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter Your Email Address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Provide your Phone Number")]
        [RegularExpression(@"^(?:\+88|88)?(01[3-9]\d{8})$", ErrorMessage = "Follow Number Format: +8801xxxxxxxxx or 01xxxxxxxxx")]
        public string Phone_no { get; set; }
        [Required]
        public string Type { get; set; }
        [Required(ErrorMessage = "Please Select Your Blood-group")]
        public string Blood_group { get; set; }
        public string Salary { get; set; }
        public string Department { get; set; }
        public string Degree { get; set; }
        public byte[] Image { get; set; }
    }
}
