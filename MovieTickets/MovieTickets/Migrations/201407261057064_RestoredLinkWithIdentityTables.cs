using System.Data.Entity.Migrations;

namespace MovieTickets.Migrations
{
    public partial class RestoredLinkWithIdentityTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IpStories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] {"ApplicationUser_Id"});
            DropIndex("dbo.IpStories", new[] {"ApplicationUser_Id"});
            AddColumn("dbo.Tickets", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.IpStories", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tickets", "ApplicationUser_Id", c => c.Int());
            AlterColumn("dbo.IpStories", "ApplicationUser_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "ApplicationUser_Id1");
            CreateIndex("dbo.IpStories", "ApplicationUser_Id1");
            AddForeignKey("dbo.IpStories", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tickets", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Tickets", "ApplicationUserId");
            DropColumn("dbo.IpStories", "ApplicationUserId");
        }

        public override void Down()
        {
            AddColumn("dbo.IpStories", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "ApplicationUserId", c => c.Int());
            DropForeignKey("dbo.Tickets", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.IpStories", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.IpStories", new[] {"ApplicationUser_Id1"});
            DropIndex("dbo.Tickets", new[] {"ApplicationUser_Id1"});
            AlterColumn("dbo.IpStories", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Tickets", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.IpStories", "ApplicationUser_Id1");
            DropColumn("dbo.Tickets", "ApplicationUser_Id1");
            CreateIndex("dbo.IpStories", "ApplicationUser_Id");
            CreateIndex("dbo.Tickets", "ApplicationUser_Id");
            AddForeignKey("dbo.Tickets", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.IpStories", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}