using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical13_Test2.Models
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DesignationName { get; set; }
    }
}