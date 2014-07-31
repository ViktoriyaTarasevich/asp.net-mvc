using System.Data.Entity.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangedLinkBeetwenPriceAndSeance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketPrices", "SeanceId", "dbo.Seances");
            DropIndex("dbo.TicketPrices", new[] {"SeanceId"});
            AddColumn("dbo.Seances", "TicketPriceId", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Seances", "TicketPriceId");
            CreateIndex("dbo.TicketPrices", "SeanceId");
            AddForeignKey("dbo.TicketPrices", "SeanceId", "dbo.Seances", "Id", cascadeDelete: true);
        }
    }
}