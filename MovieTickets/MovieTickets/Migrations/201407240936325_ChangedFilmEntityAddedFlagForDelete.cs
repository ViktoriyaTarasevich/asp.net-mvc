namespace MovieTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedFilmEntityAddedFlagForDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "IsDeleted");
        }
    }
}
