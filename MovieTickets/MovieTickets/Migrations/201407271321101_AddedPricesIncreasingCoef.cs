namespace MovieTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
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
