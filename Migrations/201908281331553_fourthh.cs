namespace FIRERISK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auditor", "PhoneNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Auditor", "PhoneNumber", c => c.String(nullable: false));
        }
    }
}
