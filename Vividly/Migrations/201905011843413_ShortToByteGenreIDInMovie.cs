namespace Vividly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShortToByteGenreIDInMovie : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Movies", new[] { "Genre_ID" });
            DropColumn("dbo.Movies", "GenreID");
            RenameColumn(table: "dbo.Movies", name: "Genre_ID", newName: "GenreID");
            AlterColumn("dbo.Movies", "GenreID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenreID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "GenreID" });
            AlterColumn("dbo.Movies", "GenreID", c => c.Short(nullable: false));
            RenameColumn(table: "dbo.Movies", name: "GenreID", newName: "Genre_ID");
            AddColumn("dbo.Movies", "GenreID", c => c.Short(nullable: false));
            CreateIndex("dbo.Movies", "Genre_ID");
        }
    }
}
