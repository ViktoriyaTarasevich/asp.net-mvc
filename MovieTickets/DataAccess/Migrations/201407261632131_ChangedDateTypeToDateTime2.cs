using System.Data.Entity.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangedDateTypeToDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Seances", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Seances", "Time", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Tickets", "DateTimeBuy",
                        c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.IpStories", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.IpStories", "Time", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }

        public override void Down()
        {
            AlterColumn("dbo.IpStories", "Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.IpStories", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "DateTimeBuy", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Seances", "Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Seances", "Date", c => c.DateTime(nullable: false));
        }
    }
}