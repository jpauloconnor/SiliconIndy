namespace SiliconIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletelessondatatable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.LessonData");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LessonData",
                c => new
                    {
                        LessonDataID = c.Int(nullable: false, identity: true),
                        LessonID = c.Int(nullable: false),
                        JavaScript = c.Boolean(nullable: false),
                        CSharp = c.Boolean(nullable: false),
                        HTML = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LessonDataID);
            
        }
    }
}
