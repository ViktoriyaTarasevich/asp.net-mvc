using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using MovieTickets.App_Start;
using MovieTickets.Models;

namespace MovieTickets.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork<MovieTicketContext> _unitOfWork;
        private IRepository<Film> _repository;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork<MovieTicketContext>();
            _repository = _unitOfWork.GetRepository<Film>();
        }
        //
        // GET: /Home/
        public ActionResult Index()
        { 
            var model = _repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult FilmGalery()
        {
            
            var model = _repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Film(int id)
        {
            var model = new List<Film>{_repository.GetById(id)};
            return View(model);
        }
	}
}