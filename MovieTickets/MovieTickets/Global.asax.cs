using System.Data.Entity;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;
using MovieTickets.Migrations;
using MovieTickets.Models;
using WebMatrix.WebData;

namespace MovieTickets
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
