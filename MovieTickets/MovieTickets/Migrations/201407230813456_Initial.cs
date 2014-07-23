namespace MovieTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        Image = c.String(nullable: false),
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
                        AspNetUserId = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seances", t => t.SeanceId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.SeanceId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IpStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ip = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        AspNetUserId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TicketCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        SurName = c.String(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.IpStories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketPrices", "TicketCategoryId", "dbo.TicketCategories");
            DropForeignKey("dbo.Places", "TicketCategoryId", "dbo.TicketCategories");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Seances", "FilmId", "dbo.Films");
            DropForeignKey("dbo.Tickets", "SeanceId", "dbo.Seances");
            DropForeignKey("dbo.TicketPrices", "SeanceId", "dbo.Seances");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Places", new[] { "TicketCategoryId" });
            DropIndex("dbo.IpStories", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Tickets", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Tickets", new[] { "SeanceId" });
            DropIndex("dbo.TicketPrices", new[] { "SeanceId" });
            DropIndex("dbo.TicketPrices", new[] { "TicketCategoryId" });
            DropIndex("dbo.Seances", new[] { "FilmId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TicketCategories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Places");
            DropTable("dbo.IpStories");
            DropTable("dbo.Tickets");
            DropTable("dbo.TicketPrices");
            DropTable("dbo.Seances");
            DropTable("dbo.Films");
        }
    }
}
