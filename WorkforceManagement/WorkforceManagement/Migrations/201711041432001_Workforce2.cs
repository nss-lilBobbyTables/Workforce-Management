namespace WorkforceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Workforce2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeesComputers", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.EmployeesComputers", "Computers_Id", "dbo.Computers");
            DropIndex("dbo.EmployeesComputers", new[] { "Employees_Id" });
            DropIndex("dbo.EmployeesComputers", new[] { "Computers_Id" });
            AddColumn("dbo.Employees", "Computers_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Computers_Id");
            AddForeignKey("dbo.Employees", "Computers_Id", "dbo.Computers", "Id");
            DropTable("dbo.EmployeesComputers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeesComputers",
                c => new
                    {
                        Employees_Id = c.Int(nullable: false),
                        Computers_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employees_Id, t.Computers_Id });
            
            DropForeignKey("dbo.Employees", "Computers_Id", "dbo.Computers");
            DropIndex("dbo.Employees", new[] { "Computers_Id" });
            DropColumn("dbo.Employees", "Computers_Id");
            CreateIndex("dbo.EmployeesComputers", "Computers_Id");
            CreateIndex("dbo.EmployeesComputers", "Employees_Id");
            AddForeignKey("dbo.EmployeesComputers", "Computers_Id", "dbo.Computers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeesComputers", "Employees_Id", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
