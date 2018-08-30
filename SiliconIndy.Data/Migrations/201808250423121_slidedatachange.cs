namespace SiliconIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slidedatachange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        SlideId = c.Int(nullable: false, identity: true),
                        LessonID = c.Int(nullable: false),
                        DeckName = c.String(nullable: false),
                        QueueSpot = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SlideId)
                .ForeignKey("dbo.Lesson", t => t.LessonID, cascadeDelete: true)
                .Index(t => t.LessonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slide", "LessonID", "dbo.Lesson");
            DropIndex("dbo.Slide", new[] { "LessonID" });
            DropTable("dbo.Slide");
        }
    }
}
