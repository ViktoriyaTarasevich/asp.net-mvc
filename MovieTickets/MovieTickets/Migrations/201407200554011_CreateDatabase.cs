namespace MovieTickets
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        FilmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .Index(t => t.FilmId);
            
            CreateTable(
                "dbo.TicketPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        TicketCategoryId = c.Int(nullable: false),
                        SeanceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seances", t => t.SeanceId, cascadeDelete: true)
                .ForeignKey("dbo.TicketCategories", t => t.TicketCategoryId, cascadeDelete: true)
                .Index(t => t.TicketCategoryId)
                .Index(t => t.SeanceId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTimeBuy = c.DateTime(nullable: false),
                        SeanceId = c.Int(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seances", t => t.SeanceId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.SeanceId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IpStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ip = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Col = c.Byte(nullable: false),
                        Row = c.Byte(nullable: false),
                        TicketCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TicketCategories", t => t.TicketCategoryId, cascadeDelete: true)
                .Index(t => t.TicketCategoryId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SurName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TicketCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketPrices", "TicketCategoryId", "dbo.TicketCategories");
            DropForeignKey("dbo.Places", "TicketCategoryId", "dbo.TicketCategories");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            DropForeignKey("dbo.IpStories", "UserId", "dbo.Users");
            DropForeignKey("dbo.Seances", "FilmId", "dbo.Films");
            DropForeignKey("dbo.Tickets", "SeanceId", "dbo.Seances");
            DropForeignKey("dbo.TicketPrices", "SeanceId", "dbo.Seances");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Places", new[] { "TicketCategoryId" });
            DropIndex("dbo.IpStories", new[] { "UserId" });
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropIndex("dbo.Tickets", new[] { "SeanceId" });
            DropIndex("dbo.TicketPrices", new[] { "SeanceId" });
            DropIndex("dbo.TicketPrices", new[] { "TicketCategoryId" });
            DropIndex("dbo.Seances", new[] { "FilmId" });
            DropTable("dbo.TicketCategories");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Places");
            DropTable("dbo.IpStories");
            DropTable("dbo.Tickets");
            DropTable("dbo.TicketPrices");
            DropTable("dbo.Seances");
            DropTable("dbo.Films");
        }
    }
}
