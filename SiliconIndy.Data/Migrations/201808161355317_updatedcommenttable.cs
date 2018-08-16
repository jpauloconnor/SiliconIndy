namespace SiliconIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedcommenttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        LessonId = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(nullable: false),
                        CommentText = c.String(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.CommentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comment");
        }
    }
}
