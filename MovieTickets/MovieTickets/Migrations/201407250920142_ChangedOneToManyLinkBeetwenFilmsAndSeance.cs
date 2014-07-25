namespace MovieTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedOneToManyLinkBeetwenFilmsAndSeance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seances", "FilmId", "dbo.Films");
            DropIndex("dbo.Seances", new[] { "FilmId" });
            AddColumn("dbo.Films", "Seance_Id", c => c.Int());
            CreateIndex("dbo.Films", "Seance_Id");
            AddForeignKey("dbo.Films", "Seance_Id", "dbo.Seances", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "Seance_Id", "dbo.Seances");
            DropIndex("dbo.Films", new[] { "Seance_Id" });
            DropColumn("dbo.Films", "Seance_Id");
            CreateIndex("dbo.Seances", "FilmId");
            AddForeignKey("dbo.Seances", "FilmId", "dbo.Films", "Id", cascadeDelete: true);
        }
    }
}
