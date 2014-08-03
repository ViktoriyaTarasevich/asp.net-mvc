using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using MovieTickets.Entities.Models;
using MovieTickets.ViewModels;

namespace MovieTickets.Controllers
{
    public class FilmController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FilmController(IUnitOfWork uof)
        {
            _unitOfWork = uof;
        }

        //
        // GET: /Admin/
        public ActionResult FilmControl()
        {
            IRepository<Film> repository = _unitOfWork.GetRepository<Film>();
            IEnumerable<Film> model = repository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            IRepository<Film> repository = _unitOfWork.GetRepository<Film>();
            repository.Delete(repository.GetById(id));
            _unitOfWork.Save();
            return RedirectToAction("FilmControl");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            IRepository<Film> repository = _unitOfWork.GetRepository<Film>();
            var model = repository.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Film model, HttpPostedFileBase file)
        {
            if (model.Title != null && model.Description != null && file != null)
            {
                IRepository<Film> repository = _unitOfWork.GetRepository<Film>();
                model.Image = file.FileName;
                repository.Update(model.Id,model);
                _unitOfWork.Save();
                return RedirectToAction("FilmControl","Film");
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Film model, HttpPostedFileBase file)
        {
            if (model.Title != null && model.Description != null && file != null)
            {
                IRepository<Film> repository = _unitOfWork.GetRepository<Film>();
                model.Image = file.FileName;
                repository.Insert(model);
                _unitOfWork.Save();
                return RedirectToAction("NewSeance", new {id = model.Id});
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
                IRepository<TicketPrice> priceRepository = _unitOfWork.GetRepository<TicketPrice>();
                TicketPrice price;
                if (!TicketHelper.IsTicketPriceIdInDataBase(priceRepository.GetAll(), model.Price))
                {
                    price = new TicketPrice {Price = model.Price};
                    priceRepository.Insert(price);
                    _unitOfWork.Save();
                }
                else
                {
                    price = priceRepository.GetAll().First(x => x.Price == model.Price);
                }
                IRepository<Seance> senceRepository = _unitOfWork.GetRepository<Seance>();
                var seance = new Seance {FilmId = id, Time = model.Time, Date = model.Date, TicketPriceId = price.Id};
                senceRepository.Insert(seance);
                _unitOfWork.Save();
                return View();
            }
            return View();
        }
    }
}