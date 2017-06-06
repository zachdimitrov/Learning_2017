namespace CodeFirstTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedTypo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Genres", name: "ParenrGenre_Id", newName: "ParentGenre_Id");
            RenameIndex(table: "dbo.Genres", name: "IX_ParenrGenre_Id", newName: "IX_ParentGenre_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Genres", name: "IX_ParentGenre_Id", newName: "IX_ParenrGenre_Id");
            RenameColumn(table: "dbo.Genres", name: "ParentGenre_Id", newName: "ParenrGenre_Id");
        }
    }
}
