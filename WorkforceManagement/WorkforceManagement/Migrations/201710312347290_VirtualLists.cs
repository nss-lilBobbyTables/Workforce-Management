namespace WorkforceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VirtualLists : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Computers_Id", "dbo.Computers");
            DropForeignKey("dbo.Employees", "TrainingPrograms_Id", "dbo.TrainingPrograms");
            DropIndex("dbo.Employees", new[] { "Computers_Id" });
            DropIndex("dbo.Employees", new[] { "TrainingPrograms_Id" });
            CreateTable(
                "dbo.EmployeesComputers",
                c => new
                    {
                        Employees_Id = c.Int(nullable: false),
                        Computers_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employees_Id, t.Computers_Id })
                .ForeignKey("dbo.Employees", t => t.Employees_Id, cascadeDelete: true)
                .ForeignKey("dbo.Computers", t => t.Computers_Id, cascadeDelete: true)
                .Index(t => t.Employees_Id)
                .Index(t => t.Computers_Id);
            
            CreateTable(
                "dbo.TrainingProgramsEmployees",
                c => new
                    {
                        TrainingPrograms_Id = c.Int(nullable: false),
                        Employees_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrainingPrograms_Id, t.Employees_Id })
                .ForeignKey("dbo.TrainingPrograms", t => t.TrainingPrograms_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employees_Id, cascadeDelete: true)
                .Index(t => t.TrainingPrograms_Id)
                .Index(t => t.Employees_Id);
            
            DropColumn("dbo.Employees", "Computers_Id");
            DropColumn("dbo.Employees", "TrainingPrograms_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "TrainingPrograms_Id", c => c.Int());
            AddColumn("dbo.Employees", "Computers_Id", c => c.Int());
            DropForeignKey("dbo.TrainingProgramsEmployees", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.TrainingProgramsEmployees", "TrainingPrograms_Id", "dbo.TrainingPrograms");
            DropForeignKey("dbo.EmployeesComputers", "Computers_Id", "dbo.Computers");
            DropForeignKey("dbo.EmployeesComputers", "Employees_Id", "dbo.Employees");
            DropIndex("dbo.TrainingProgramsEmployees", new[] { "Employees_Id" });
            DropIndex("dbo.TrainingProgramsEmployees", new[] { "TrainingPrograms_Id" });
            DropIndex("dbo.EmployeesComputers", new[] { "Computers_Id" });
            DropIndex("dbo.EmployeesComputers", new[] { "Employees_Id" });
            DropTable("dbo.TrainingProgramsEmployees");
            DropTable("dbo.EmployeesComputers");
            CreateIndex("dbo.Employees", "TrainingPrograms_Id");
            CreateIndex("dbo.Employees", "Computers_Id");
            AddForeignKey("dbo.Employees", "TrainingPrograms_Id", "dbo.TrainingPrograms", "Id");
            AddForeignKey("dbo.Employees", "Computers_Id", "dbo.Computers", "Id");
        }
    }
}
