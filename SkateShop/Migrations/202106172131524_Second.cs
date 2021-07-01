namespace SkateShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accessories", "info", c => c.String());
            AddColumn("dbo.Accessories", "sale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Decks", "info", c => c.String());
            AddColumn("dbo.Decks", "sale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Trucks", "info", c => c.String());
            AddColumn("dbo.Trucks", "sale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Wheels", "info", c => c.String());
            AddColumn("dbo.Wheels", "sale", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wheels", "sale");
            DropColumn("dbo.Wheels", "info");
            DropColumn("dbo.Trucks", "sale");
            DropColumn("dbo.Trucks", "info");
            DropColumn("dbo.Decks", "sale");
            DropColumn("dbo.Decks", "info");
            DropColumn("dbo.Accessories", "sale");
            DropColumn("dbo.Accessories", "info");
        }
    }
}
