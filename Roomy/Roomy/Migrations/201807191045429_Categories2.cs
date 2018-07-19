namespace Roomy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categories2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "RoomID", "dbo.Rooms");
            DropIndex("dbo.Categories", new[] { "RoomID" });
            AddColumn("dbo.Rooms", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "CategoryID");
            AddForeignKey("dbo.Rooms", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
            DropColumn("dbo.Categories", "RoomID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "RoomID", c => c.Int());
            DropForeignKey("dbo.Rooms", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Rooms", new[] { "CategoryID" });
            DropColumn("dbo.Rooms", "CategoryID");
            CreateIndex("dbo.Categories", "RoomID");
            AddForeignKey("dbo.Categories", "RoomID", "dbo.Rooms", "ID");
        }
    }
}
