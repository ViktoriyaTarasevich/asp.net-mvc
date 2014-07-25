namespace MovieTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoreOneToManyLinkBeetwenFilmsAndSeance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "Seance_Id", "dbo.Seances");
            DropIndex("dbo.Films", new[] { "Seance_Id" });
            CreateIndex("dbo.Seances", "FilmId");
            AddForeignKey("dbo.Seances", "FilmId", "dbo.Films", "Id", cascadeDelete: true);
            DropColumn("dbo.Films", "Seance_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "Seance_Id", c => c.Int());
            DropForeignKey("dbo.Seances", "FilmId", "dbo.Films");
            DropIndex("dbo.Seances", new[] { "FilmId" });
            CreateIndex("dbo.Films", "Seance_Id");
            AddForeignKey("dbo.Films", "Seance_Id", "dbo.Seances", "Id");
        }
    }
}
