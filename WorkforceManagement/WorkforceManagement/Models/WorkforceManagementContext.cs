using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorkforceManagement.Models
{
    public class WorkforceManagementContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WorkforceManagementContext() : base("name=WorkforceManagementContext")
        {
        }

        public System.Data.Entity.DbSet<WorkforceManagement.Models.Employees> Employees { get; set; }

        public System.Data.Entity.DbSet<WorkforceManagement.Models.Computers> Computers { get; set; }

        public System.Data.Entity.DbSet<WorkforceManagement.Models.Departments> Departments { get; set; }

        public System.Data.Entity.DbSet<WorkforceManagement.Models.TrainingPrograms> TrainingPrograms { get; set; }
    }
}
