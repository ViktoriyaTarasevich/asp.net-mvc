using System.Web.Mvc;

namespace MovieTickets.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Register()
        {
            return View();
        }



        public ActionResult LogIn()
        {
            return View();
        }
	}
}