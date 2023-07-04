namespace Practical13_Test2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false, storeType: "date"),
                        MobileNumber = c.String(nullable: false),
                        Address = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DesignationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.DesignationID, cascadeDelete: true)
                .Index(t => t.DesignationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DesignationID", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "DesignationID" });
            DropTable("dbo.Employees");
            DropTable("dbo.Designations");
        }
    }
}
