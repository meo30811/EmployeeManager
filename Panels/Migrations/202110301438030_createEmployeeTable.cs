namespace Panels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblDepartments",
                c => new
                    {
                        Department_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Department_Id);
            
            CreateTable(
                "dbo.tblEmployees",
                c => new
                    {
                        Emp_ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Design = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        address = c.String(),
                        Gender = c.String(),
                        Employee_ID = c.String(nullable: false),
                        Date_today = c.DateTime(nullable: false),
                        Date_from = c.DateTime(nullable: false),
                        Date_to = c.DateTime(nullable: false),
                        shift = c.String(nullable: false),
                        Department_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Emp_ID)
                .ForeignKey("dbo.tblDepartments", t => t.Department_Id, cascadeDelete: true)
                .Index(t => t.Department_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblEmployees", "Department_Id", "dbo.tblDepartments");
            DropIndex("dbo.tblEmployees", new[] { "Department_Id" });
            DropTable("dbo.tblEmployees");
            DropTable("dbo.tblDepartments");
        }
    }
}
