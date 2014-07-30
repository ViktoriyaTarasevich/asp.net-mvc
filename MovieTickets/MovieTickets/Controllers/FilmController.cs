using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using DataAccess.UnitOfWork;
using MovieTickets.Context;
using MovieTickets.Entities.Models;
using MovieTickets.ViewModels;

namespace MovieTickets.Controllers
{
    public class FilmController : Controller
    {
        
        private readonly IUnitOfWork<MovieTicketContext> _unitOfWork;

        public FilmController(IUnitOfWork<MovieTicketContext> uof)
        {
            _unitOfWork = uof;
            
        }

        //
        // GET: /Admin/
        public ActionResult FilmControl()
        {
            var repository = _unitOfWork.GetRepository<Film>();
            IEnumerable<Film> model = repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var repository = _unitOfWork.GetRepository<Film>();
            repository.Delete(repository.GetById(id));
            _unitOfWork.Save();
            Film mod = repository.GetById(id);
            return RedirectToAction("FilmControl");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Film model, HttpPostedFileBase file)
        {
            if (model.Title != null && model.Description !=null && file != null)
            {
                var repository = _unitOfWork.GetRepository<Film>();
                model.Image = file.FileName;
                repository.Insert(model);
                _unitOfWork.Save();
                return RedirectToAction("NewSeance", new { id = model.Id });
            }
            return View();
        }


        public ActionResult NewSeance()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewSeance(SeanceViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var priceRepository = _unitOfWork.GetRepository<TicketPrice>();
                var price = new TicketPrice {Price = model.Price};
                priceRepository.Insert(price); 
                _unitOfWork.Save();
                var senceRepository = _unitOfWork.GetRepository<Seance>();
                var seance = new Seance {FilmId = id, Time = model.Time, Date = model.Date, TicketPriceId = price.Id};
                senceRepository.Insert(seance);
                _unitOfWork.Save();
                return View();
            }
            return View();
        }
    }
}