using System.Data.Entity.Migrations;

namespace DataAccess.Migrations
{
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