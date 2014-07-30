using System.Web.Mvc;
using System.Web.Routing;

namespace MovieTickets
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Hall",
                "Home/Hall/{id}",
                new {controller = "Ticket", action = "Hall", id = UrlParameter.Optional}
                );

            routes.MapRoute(
                "Delete",
                "Accpunt/Delete/{id}",
                new { controller = "Ticket", action = "Delete", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}