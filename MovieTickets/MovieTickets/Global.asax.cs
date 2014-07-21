using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using DataAccess;
using MovieTickets.Migrations;
using MovieTickets.Models;

namespace MovieTickets
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieTicketContext,Configuration>());
        }
    }
}
