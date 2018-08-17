namespace SiliconIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvalueforlessontype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lesson", "JavaScript", c => c.Boolean(nullable: false));
            AddColumn("dbo.Lesson", "CSharp", c => c.Boolean(nullable: false));
            AddColumn("dbo.Lesson", "HTML", c => c.Boolean(nullable: false));
            DropColumn("dbo.Lesson", "LessonType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lesson", "LessonType", c => c.Int(nullable: false));
            DropColumn("dbo.Lesson", "HTML");
            DropColumn("dbo.Lesson", "CSharp");
            DropColumn("dbo.Lesson", "JavaScript");
        }
    }
}
