namespace Practical_13.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Practical_13.Models.EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Practical_13.Models.EmployeeContext";
        }

        protected override void Seed(Practical_13.Models.EmployeeContext context)
        {
            context.employees.AddOrUpdate(e => e.Id, new Models.Employee() { Name="Jay",DOB=Convert.ToDateTime("21-08-2002").Date,Age=22}, new Models.Employee() { Name = "Jill", DOB = Convert.ToDateTime("17-04-2001").Date, Age = 21 }, new Models.Employee() { Name = "Abhi", DOB = Convert.ToDateTime("15-08-2002").Date, Age = 22 });
            context.SaveChanges();
        }
    }
}
