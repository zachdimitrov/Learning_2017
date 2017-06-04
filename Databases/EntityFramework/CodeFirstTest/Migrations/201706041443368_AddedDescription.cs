namespace CodeFirstTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Description", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Description");
        }
    }
}
