using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.Mvc;
using System.Web.Routing;
using MovieTickets.Models;

namespace MovieTickets
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<MovieTicketContext>(new MigrateDatabaseToLatestVersion<MovieTicketContext,Configuration>());
        }
    }

    public sealed class Configuration : DbMigrationsConfiguration<MovieTicketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MovieTicketContext context)
        {
            base.Seed(context);
        }
    }
}
