using System.Web.Mvc;

namespace MovieTickets.HtmlHelpers
{
    public static class ActionHelper
    {
        public static string ActionUri(this HtmlHelper html, string action, string controller)
        {
            return new UrlHelper(html.ViewContext.RequestContext).Action(action, controller);
        }
    }
}