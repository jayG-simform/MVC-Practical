using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practical13_Test2.Models
{
    public class CompanyDBContext : DbContext
    {
        public CompanyDBContext():base("name=Practical13_Test2") 
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CompanyDBContext>());
        }
        
        public DbSet<Designation> designations { get; set; }
        public DbSet<Employee> employees {get;set;}
    }
}