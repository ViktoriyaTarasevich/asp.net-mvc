using System.Data.Entity.Migrations;

namespace DataAccess.Migrations
{
    public partial class RemovedLinkFromTicketPriceToTicketCategoryContinue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketPrices", "TicketCategory_Id", "dbo.TicketCategories");
            DropIndex("dbo.TicketPrices", new[] {"TicketCategory_Id"});
            DropColumn("dbo.TicketPrices", "TicketCategory_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.TicketPrices", "TicketCategory_Id", c => c.Int());
            CreateIndex("dbo.TicketPrices", "TicketCategory_Id");
            AddForeignKey("dbo.TicketPrices", "TicketCategory_Id", "dbo.TicketCategories", "Id");
        }
    }
}