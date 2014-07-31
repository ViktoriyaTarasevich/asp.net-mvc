using System.Data.Entity.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddFlagToTicketIsBought : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "IsBought", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Tickets", "IsBought");
        }
    }
}