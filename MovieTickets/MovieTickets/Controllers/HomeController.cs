using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.UnitOfWork;
using MovieTickets.Models;

namespace MovieTickets.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //var context = new MovieTicketContext();
            //context.Users.Add(new User {Name = "Ptencha", SurName = "Zla", Password = "123455", RoleId = 2});
            //context.SaveChanges();
            var uow = new UnitOfWork<MovieTicketContext>();
            var rep = uow.GetRepository<User>();
            rep.Insert(new User { Name = "Ptencha", SurName = "Zla", Password = "123455", RoleId = 2 });
            uow.Save();
            return View();
        }
	}
}