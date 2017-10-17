namespace WorkforceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        Model = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Computers_Id = c.Int(),
                        Departments_Id = c.Int(),
                        TrainingPrograms_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Computers", t => t.Computers_Id)
                .ForeignKey("dbo.Departments", t => t.Departments_Id)
                .ForeignKey("dbo.TrainingPrograms", t => t.TrainingPrograms_Id)
                .Index(t => t.Computers_Id)
                .Index(t => t.Departments_Id)
                .Index(t => t.TrainingPrograms_Id);
            
            CreateTable(
                "dbo.TrainingPrograms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        MaxCapacity = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "TrainingPrograms_Id", "dbo.TrainingPrograms");
            DropForeignKey("dbo.Employees", "Departments_Id", "dbo.Departments");
            DropForeignKey("dbo.Employees", "Computers_Id", "dbo.Computers");
            DropIndex("dbo.Employees", new[] { "TrainingPrograms_Id" });
            DropIndex("dbo.Employees", new[] { "Departments_Id" });
            DropIndex("dbo.Employees", new[] { "Computers_Id" });
            DropTable("dbo.TrainingPrograms");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.Computers");
        }
    }
}
