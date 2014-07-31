using System.Data.Entity.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedPricesIncreasingCoef : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketCategories", "PriceCoef", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.TicketCategories", "PriceCoef");
        }
    }
}