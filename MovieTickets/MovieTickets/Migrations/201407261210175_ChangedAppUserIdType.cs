using System.Data.Entity.Migrations;

namespace MovieTickets.Migrations
{
    public partial class ChangedAppUserIdType : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.IpStories", name: "ApplicationUser_Id1", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.Tickets", name: "ApplicationUser_Id1", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.Tickets", name: "IX_ApplicationUser_Id1", newName: "IX_ApplicationUserId");
            RenameIndex(table: "dbo.IpStories", name: "IX_ApplicationUser_Id1", newName: "IX_ApplicationUserId");
            DropColumn("dbo.Tickets", "ApplicationUser_Id");
            DropColumn("dbo.IpStories", "ApplicationUser_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.IpStories", "ApplicationUser_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "ApplicationUser_Id", c => c.Int());
            RenameIndex(table: "dbo.IpStories", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id1");
            RenameIndex(table: "dbo.Tickets", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id1");
            RenameColumn(table: "dbo.Tickets", name: "ApplicationUserId", newName: "ApplicationUser_Id1");
            RenameColumn(table: "dbo.IpStories", name: "ApplicationUserId", newName: "ApplicationUser_Id1");
        }
    }
}