namespace Vividly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_ID = c.Int(nullable: false),
                        Movie_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_ID, cascadeDelete: true)
                .Index(t => t.Customer_ID)
                .Index(t => t.Movie_ID);
            
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movie_ID" });
            DropIndex("dbo.Rentals", new[] { "Customer_ID" });
            DropColumn("dbo.Movies", "NumberAvailable");
            DropTable("dbo.Rentals");
        }
    }
}
