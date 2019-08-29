namespace FIRERISK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auditor", "AuditorName", c => c.String(nullable: false));
            AlterColumn("dbo.Auditor", "Organization", c => c.String(nullable: false));
            AlterColumn("dbo.Auditor", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Auditor", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Auditor", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Auditor", "EmailAddress", c => c.String());
            AlterColumn("dbo.Auditor", "Organization", c => c.String());
            AlterColumn("dbo.Auditor", "AuditorName", c => c.String());
        }
    }
}
