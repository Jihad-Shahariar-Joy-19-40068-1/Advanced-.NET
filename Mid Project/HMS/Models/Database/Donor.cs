//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMS.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Donor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Phone_no { get; set; }
        public string Blood_group { get; set; }
        [Required]
        public string Organ_type { get; set; }
        [Required]
        public string Blood_pressure { get; set; }
        [Required]
        public string Diabetes { get; set; }
        [Required]
        public string Allergy { get; set; }
        [Required]
        public string Asthama { get; set; }
        public string Approval { get; set; }
        public string Approved_by { get; set; }
        public string Location { get; set; }
    }
}
