namespace FIRERISK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auditor",
                c => new
                    {
                        RegistrationNo = c.String(nullable: false, maxLength: 128),
                        AuditorName = c.String(),
                        Organization = c.String(),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.RegistrationNo);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CID = c.String(nullable: false, maxLength: 128),
                        Comments = c.String(),
                        ItemID = c.String(maxLength: 128),
                        RateID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CID)
                .ForeignKey("dbo.Item", t => t.ItemID)
                .ForeignKey("dbo.Rate", t => t.RateID)
                .Index(t => t.ItemID)
                .Index(t => t.RateID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemID = c.String(nullable: false, maxLength: 128),
                        ItemName = c.String(),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateTable(
                "dbo.Rate",
                c => new
                    {
                        RateID = c.String(nullable: false, maxLength: 128),
                        RateValue = c.String(),
                    })
                .PrimaryKey(t => t.RateID);
            
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
                        RegID = c.String(nullable: false, maxLength: 128),
                        WorkplaceName = c.String(),
                        PostalAddress = c.String(),
                        PhysicalAddress = c.String(),
                        MaleEmployees = c.Int(nullable: false),
                        FemaleEmployees = c.Int(nullable: false),
                        SiteDescription = c.String(),
                        OnAttachment = c.Int(nullable: false),
                        DisabledNo = c.Int(nullable: false),
                        HealthOfficer = c.String(),
                        Date = c.DateTime(nullable: false),
                        IndustryID = c.String(),
                        Industry_IndutryID = c.Int(),
                    })
                .PrimaryKey(t => t.RegID)
                .ForeignKey("dbo.Industry", t => t.Industry_IndutryID)
                .Index(t => t.Industry_IndutryID);
            
            CreateTable(
                "dbo.Observation",
                c => new
                    {
                        ObID = c.String(nullable: false, maxLength: 128),
                        Statement = c.String(),
                        RuleID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ObID)
                .ForeignKey("dbo.Rule", t => t.RuleID)
                .Index(t => t.RuleID);
            
            CreateTable(
                "dbo.Rule",
                c => new
                    {
                        RuleID = c.String(nullable: false, maxLength: 128),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.RuleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Observation", "RuleID", "dbo.Rule");
            DropForeignKey("dbo.Workplace", "Industry_IndutryID", "dbo.Industry");
            DropForeignKey("dbo.Comment", "RateID", "dbo.Rate");
            DropForeignKey("dbo.Comment", "ItemID", "dbo.Item");
            DropIndex("dbo.Observation", new[] { "RuleID" });
            DropIndex("dbo.Workplace", new[] { "Industry_IndutryID" });
            DropIndex("dbo.Comment", new[] { "RateID" });
            DropIndex("dbo.Comment", new[] { "ItemID" });
            DropTable("dbo.Rule");
            DropTable("dbo.Observation");
            DropTable("dbo.Workplace");
            DropTable("dbo.Industry");
            DropTable("dbo.Rate");
            DropTable("dbo.Item");
            DropTable("dbo.Comment");
            DropTable("dbo.Auditor");
        }
    }
}
