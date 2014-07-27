namespace MovieTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedLinkFromTicketPriceToTicketCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketPrices", "TicketCategoryId", "dbo.TicketCategories");
            DropIndex("dbo.TicketPrices", new[] { "TicketCategoryId" });
            RenameColumn(table: "dbo.TicketPrices", name: "TicketCategoryId", newName: "TicketCategory_Id");
            AlterColumn("dbo.TicketPrices", "TicketCategory_Id", c => c.Int());
            CreateIndex("dbo.TicketPrices", "TicketCategory_Id");
            AddForeignKey("dbo.TicketPrices", "TicketCategory_Id", "dbo.TicketCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketPrices", "TicketCategory_Id", "dbo.TicketCategories");
            DropIndex("dbo.TicketPrices", new[] { "TicketCategory_Id" });
            AlterColumn("dbo.TicketPrices", "TicketCategory_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.TicketPrices", name: "TicketCategory_Id", newName: "TicketCategoryId");
            CreateIndex("dbo.TicketPrices", "TicketCategoryId");
            AddForeignKey("dbo.TicketPrices", "TicketCategoryId", "dbo.TicketCategories", "Id", cascadeDelete: true);
        }
    }
}
