namespace SiliconIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commenttitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comment", "Title");
        }
    }
}
