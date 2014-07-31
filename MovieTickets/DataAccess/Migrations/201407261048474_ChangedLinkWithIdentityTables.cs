using System.Data.Entity.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangedLinkWithIdentityTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "ApplicationUserId", c => c.Int());
            AddColumn("dbo.IpStories", "ApplicationUserId", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "AspNetUserId");
            DropColumn("dbo.IpStories", "AspNetUserId");
        }

        public override void Down()
        {
            AddColumn("dbo.IpStories", "AspNetUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "AspNetUserId", c => c.Int());
            DropColumn("dbo.IpStories", "ApplicationUserId");
            DropColumn("dbo.Tickets", "ApplicationUserId");
        }
    }
}