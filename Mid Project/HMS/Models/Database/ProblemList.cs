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

    public partial class ProblemList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Problem { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public int Room_no { get; set; }
    }
}