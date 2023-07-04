using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practical_13.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext():base("name=Practical13") { }
        public DbSet<Employee> employees { get; set; }
    }
}