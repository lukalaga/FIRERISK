namespace FIRERISK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rule", "SubHeading", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rule", "SubHeading");
        }
    }
}
