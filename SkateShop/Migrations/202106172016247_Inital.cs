namespace SkateShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Int(nullable: false),
                        img = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Completes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Int(nullable: false),
                        info = c.String(),
                        img = c.String(),
                        deck_Id = c.Int(),
                        truck_Id = c.Int(),
                        wheel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Decks", t => t.deck_Id)
                .ForeignKey("dbo.Trucks", t => t.truck_Id)
                .ForeignKey("dbo.Wheels", t => t.wheel_Id)
                .Index(t => t.deck_Id)
                .Index(t => t.truck_Id)
                .Index(t => t.wheel_Id);
            
            CreateTable(
                "dbo.Decks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Int(nullable: false),
                        img = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trucks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Int(nullable: false),
                        img = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wheels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Int(nullable: false),
                        img = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Completes", "wheel_Id", "dbo.Wheels");
            DropForeignKey("dbo.Completes", "truck_Id", "dbo.Trucks");
            DropForeignKey("dbo.Completes", "deck_Id", "dbo.Decks");
            DropIndex("dbo.Completes", new[] { "wheel_Id" });
            DropIndex("dbo.Completes", new[] { "truck_Id" });
            DropIndex("dbo.Completes", new[] { "deck_Id" });
            DropTable("dbo.Wheels");
            DropTable("dbo.Trucks");
            DropTable("dbo.Decks");
            DropTable("dbo.Completes");
            DropTable("dbo.Accessories");
        }
    }
}
