using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using Microsoft.AspNet.Identity;
using MovieTickets.Entities.Models;

namespace MovieTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Film> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork uof)
        {
            _unitOfWork = uof;
            _repository = uof.GetRepository<Film>();
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            IEnumerable<Film> model = _repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult FilmGalery()
        {
            IEnumerable<Film> model = _repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Film(int id)
        {
            var model = new List<Film> {_repository.GetById(id)};
            if (model[0] == null) return RedirectToAction("Index", "Home");
            return View(model);
        }

        public ActionResult FullTextSearch(string searchString)
        {
            IEnumerable<Film> model = _repository.GetAll();
            List<Film> serchaResultModel =
                model.Where(x => x.Description.Contains(searchString) || x.Title.Contains(searchString)).ToList();

            return View("FilmGalery", serchaResultModel);
        }

        public ActionResult BuyResult()
        {
            IRepository<Ticket> repository = _unitOfWork.GetRepository<Ticket>();
            IEnumerable<Ticket> tickets = repository.GetAll();
            foreach (Ticket ticket in tickets.Where(ticket => ticket.ApplicationUserId == User.Identity.GetUserId()))
            {
                ticket.IsBought = true;
            }
            _unitOfWork.Save();
            ViewBag.Action = "Потрачено.";
            return View();
        }
    }
}