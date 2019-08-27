namespace FIRERISK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Industry",
                c => new
                    {
                        IndutryID = c.Int(nullable: false, identity: true),
                        IndustryType = c.String(),
                    })
                .PrimaryKey(t => t.IndutryID);
            
            CreateTable(
                "dbo.Workplace",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WorkplaceName = c.String(),
                        PostalAddress = c.String(),
                        PhysicalAddress = c.String(),
                        MaleEmployees = c.Int(nullable: false),
                        FemaleEmployees = c.Int(nullable: false),
                        SiteDescription = c.String(),
                        HealthOfficer = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Workplace");
            DropTable("dbo.Industry");
        }
    }
}
