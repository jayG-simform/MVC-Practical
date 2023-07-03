using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_12.Models
{
    public class CountEmpByDesination : Test3_Employee
    {
        public string Designation { get; set; }

        public int Count { get; set; }
    }
}