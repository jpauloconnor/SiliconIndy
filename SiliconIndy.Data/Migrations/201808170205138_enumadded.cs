namespace SiliconIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enumadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "LessonId", "dbo.Lesson");
            DropIndex("dbo.Comment", new[] { "LessonId" });
            AddColumn("dbo.Lesson", "LessonType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lesson", "LessonType");
            CreateIndex("dbo.Comment", "LessonId");
            AddForeignKey("dbo.Comment", "LessonId", "dbo.Lesson", "LessonId", cascadeDelete: true);
        }
    }
}
