using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical_12.Models
{
    public class Test3_Designation
    {
        [Key]
        public int DesignationId { get; set; }
        [Required]
        [StringLength(50)]
        public string DesignationName { get; set; }

    }
}