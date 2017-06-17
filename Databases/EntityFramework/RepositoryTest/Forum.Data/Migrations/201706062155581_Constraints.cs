namespace Forum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Constraints : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            AlterColumn("dbo.Categories", "Name", c => c.String(maxLength: 40));
            AlterColumn("dbo.Posts", "Title", c => c.String(maxLength: 40));
            AlterColumn("dbo.Posts", "CategoryId", c => c.Int());
            AlterColumn("dbo.Tags", "Text", c => c.String(maxLength: 40));
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            AlterColumn("dbo.Tags", "Text", c => c.String());
            AlterColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
