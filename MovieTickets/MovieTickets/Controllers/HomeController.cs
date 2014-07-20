using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieTickets.Models;

namespace MovieTickets.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var context = new MovieTicketContext();
            
            context.SaveChanges();
            return View();
        }
	}
}