namespace FIRERISK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        AuditorName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        RememberMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AuditorName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserLogin");
        }
    }
}
