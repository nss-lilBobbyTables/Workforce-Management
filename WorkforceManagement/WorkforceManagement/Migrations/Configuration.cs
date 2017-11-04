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
            //
                context.Departments.AddOrUpdate(
                  p => p.Name,
                  new Departments { Name = "Pet products", Description = "Cat shoes", Type = DepartmentType.Shoes },
                  new Departments { Name = "Gadget", Description = "Electronic key", Type = DepartmentType.Electronics },
                  new Departments { Name = "Dishes", Description = "China dinnerware", Type = DepartmentType.Housewares }
                );
            //
        }
    }
}
