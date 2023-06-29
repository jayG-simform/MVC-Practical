using Practical_11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practical_11.Data
{
    public static class EmployeeData
    {
        public static List<Employee> employees;
        
        static EmployeeData()
        {
            employees = new List<Employee>()
            {
                new Employee{Id=1, Name="Jay",DOB="21/08/2002 ", Address="Rajkot"},
                new Employee{Id=2, Name="Jil",DOB="17-06-2002", Address="Anand"},
                new Employee{Id=3, Name="Abhi",DOB="15-06-2002", Address="Morbi"},
                new Employee{Id=4, Name="Stuti",DOB="07-05-2002", Address="Jamanagar"},
                new Employee{Id=5, Name="Abhay",DOB="06-09-2002", Address="Gondal"},
                new Employee{Id=6, Name="Parthiv",DOB="29-03-2002", Address="Rajkot"},
            };
        }
    }
}