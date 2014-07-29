using System.Collections.Generic;
using System.Web.Mvc;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using MovieTickets.App_Start;
using MovieTickets.Entities.Models;


namespace MovieTickets.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork<MovieTicketContext> _unitOfWork;
        private IRepository<Film> _repository;

        public HomeController()
        {
            this._unitOfWork = new UnitOfWork<MovieTicketContext>();
            this._repository = this._unitOfWork.GetRepository<Film>();
        }
        //
        // GET: /Home/
        public ActionResult Index()
        { 
            var model = this._repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult FilmGalery()
        {
            
            var model = this._repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Film(int id)
        {
            var model = new List<Film>{this._repository.GetById(id)};
            return View(model);
        }
	}
}