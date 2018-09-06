namespace SiliconIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gitlessonprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lesson", "Git", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lesson", "Git");
        }
    }
}
