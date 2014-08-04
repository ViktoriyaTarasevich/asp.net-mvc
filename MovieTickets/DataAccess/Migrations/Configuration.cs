using System.Data.Entity.Migrations;
using DataAccess.Context;
using MovieTickets.Entities.Models;

namespace DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MovieTicketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieTicketContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //int tempType = 1;
            //for (int i = 1; i < 6; i++)
            //{
            //    for (int j = 1; j < 11; j++)
            //    {
            //        if (i < 3)
            //        {
            //            tempType = 2;
            //        }
            //        if (i > 2 && i < 5)
            //        {
            //            tempType = 1;
            //        }
            //        if (i == 5)
            //        {
            //            tempType = 3;
            //        }
            //        context.Places.AddOrUpdate(
            //            new Place {Col = (byte) j, Row = (byte) i, TicketCategoryId = tempType}
            //            );
            //    }
            //}
        }
    }
}