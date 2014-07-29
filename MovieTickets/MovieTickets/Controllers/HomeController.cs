using System.Collections.Generic;
using System.Web.Mvc;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using MovieTickets.App_Start;
using MovieTickets.Context;
using MovieTickets.Entities.Models;

namespace MovieTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Film> _repository;
        private readonly IUnitOfWork<MovieTicketContext> _unitOfWork;

        public HomeController(IUnitOfWork<MovieTicketContext> uof)
        {
            _unitOfWork = uof;
            _repository = _unitOfWork.GetRepository<Film>();
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
            return View(model);
        }
    }
}