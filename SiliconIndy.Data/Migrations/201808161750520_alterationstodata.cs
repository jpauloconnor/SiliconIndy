namespace SiliconIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterationstodata : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Comment", "LessonId");
            AddForeignKey("dbo.Comment", "LessonId", "dbo.Lesson", "LessonId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "LessonId", "dbo.Lesson");
            DropIndex("dbo.Comment", new[] { "LessonId" });
        }
    }
}
