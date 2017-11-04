namespace WorkforceManagement.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WorkforceManagement.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WorkforceManagement.Models.WorkforceManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WorkforceManagement.Models.WorkforceManagementContext";
        }

        protected override void Seed(WorkforceManagement.Models.WorkforceManagementContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            Departments petProducts = new Departments { Name = "Pet products", Description = "Cat shoes", Type = DepartmentType.Shoes };
            Departments gadgets = new Departments { Name = "Gadgets", Description = "Electronic key", Type = DepartmentType.Electronics };
            Departments dishes = new Departments { Name = "Dishes", Description = "China dinnerware", Type = DepartmentType.Housewares };
            context.Departments.AddOrUpdate(
                  p => p.Name,
                  petProducts,
                  gadgets,
                  dishes
                );

            context.Employees.AddOrUpdate(
              p => p.JobTitle,
              new Employees
              {
                  JobTitle = "Chief Simpsons Officer",
                  FirstName = "Dwayne",
                  LastName = "Pate",
                  Departments = gadgets,
                  StartDate = new DateTime(2017, 1, 1)
              },
              new Employees
              {
                  JobTitle = "Chief Chief",
                  FirstName = "Anessa",
                  LastName = "Ortner",
                  Departments = petProducts,
                  StartDate = new DateTime(2017, 1, 1)
              },
              new Employees
              {
                  JobTitle = "Chief Butcher",
                  FirstName = "Marcus",
                  LastName = "Gill",
                  Departments = dishes,
                  StartDate = new DateTime(2017, 1, 1)
              },
              new Employees
              {
                  JobTitle = "Chief Baker",
                  FirstName = "Heather",
                  LastName = "Thacker",
                  Departments = petProducts,
                  StartDate = new DateTime(2017, 1, 1)
              },
              new Employees
              {
                  JobTitle = "Chief Candlestick Maker",
                  FirstName = "Bryan",
                  LastName = "Miller",
                  Departments = dishes,
                  StartDate = new DateTime(2017, 1, 1)
              }
            );


            //
        }
    }
}
