namespace Roomy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedAt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "CreatedAt", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
