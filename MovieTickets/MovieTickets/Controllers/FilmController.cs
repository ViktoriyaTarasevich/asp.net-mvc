using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using MovieTickets.App_Start;
using MovieTickets.Context;
using MovieTickets.Entities.Models;
using MovieTickets.ViewModels;

namespace MovieTickets.Controllers
{
    public class FilmController : Controller
    {
        private readonly IRepository<Film> _repository;
        private readonly IUnitOfWork<MovieTicketContext> _unitOfWork;
        private int _newFilmId;

        public FilmController(IUnitOfWork<MovieTicketContext> uof)
        {
            _unitOfWork = uof;
            _repository = _unitOfWork.GetRepository<Film>();
        }

        //
        // GET: /Admin/
        public ActionResult FilmControl()
        {
            IEnumerable<Film> model = _repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _repository.Delete(_repository.GetById(id));
            _unitOfWork.Save();
            Film mod = _repository.GetById(id);
            return RedirectToAction("FilmControl");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Film model, HttpPostedFileBase file)
        {
            model.Image = file.FileName;
            int idFilm = 0;
            _repository.Insert(model);
            _unitOfWork.Save();
            _newFilmId = model.Id;
            IEnumerable<Film> films = _repository.GetAll();
            foreach (Film film in films)
            {
                if (film.Title == model.Title)
                {
                    idFilm = film.Id;
                    break;
                }
            }
            return RedirectToAction("NewSeance", new {id = idFilm});
        }


        public ActionResult NewSeance()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewSeance(SeanceViewModel model, int id)
        {
            IRepository<TicketPrice> priceRepository = _unitOfWork.GetRepository<TicketPrice>();
            var price = new TicketPrice {Price = model.Price};
            priceRepository.Insert(price);
            IRepository<Seance> senceRepository = _unitOfWork.GetRepository<Seance>();
            var seance = new Seance {FilmId = id, Time = model.Time, Date = model.Date, TicketPriceId = price.Id};
            senceRepository.Insert(seance);
            _unitOfWork.Save();
            return View();
        }
    }
}