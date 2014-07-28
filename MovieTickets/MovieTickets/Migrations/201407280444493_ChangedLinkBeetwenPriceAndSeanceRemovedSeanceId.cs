namespace MovieTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedLinkBeetwenPriceAndSeanceRemovedSeanceId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TicketPrices", "SeanceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketPrices", "SeanceId", c => c.Int(nullable: false));
        }
    }
}
