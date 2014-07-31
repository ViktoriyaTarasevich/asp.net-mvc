using System.Data.Entity.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangedFilmEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Films", "IsDeleted");
        }

        public override void Down()
        {
            AddColumn("dbo.Films", "IsDeleted", c => c.Boolean(nullable: false));
        }
    }
}