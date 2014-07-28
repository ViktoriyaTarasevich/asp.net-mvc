using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using MovieTickets.App_Start;
using MovieTickets.Models;
using MovieTickets.ViewModels;

namespace MovieTickets.Controllers
{
    public class TicketController : Controller
    {
        private UnitOfWork<MovieTicketContext> _unitOfWork;
        private IRepository<Ticket> _repository;

        public TicketController()
        {
            this._unitOfWork = new UnitOfWork<MovieTicketContext>();
            this._repository = _unitOfWork.GetRepository<Ticket>();
        }
        // GET: Ticket

        [HttpGet]
        public ActionResult GetSeance(int idFilm)
        {
            var model = new HallViewModel();
            var seanceRepository = this._unitOfWork.GetRepository<Seance>();
            var seances = seanceRepository.GetAll();
            model.Seances = new List<SelectListItem>();
            foreach (var seance in seances)
            {
                if (seance.FilmId == idFilm)
                {
                    model.Seances.Add(new SelectListItem
                        {
                            Text = (seance.Date.ToShortDateString() + ":" + seance.Time.ToShortTimeString()), 
                            Value = seance.Id.ToString(CultureInfo.InvariantCulture)
                        });

                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult GetSeance(HallViewModel model)
        {
            return RedirectToAction("Hall", "Ticket", new {idSeance = model.SeanceId});
        }

        
        [HttpGet]
        public ActionResult Hall(int idSeance)
        {
            var model = new HallViewModel();
            var tickets = this._repository.GetAll();
            var array = (from ticket in tickets where ticket.ApplicationUserId != null select ticket).ToList();
            model.PlacesId = new List<int>();
            foreach (var i in array)
            {
                model.PlacesId.Add(i.PlaceId);
            }
            return View(model);
        }

        public ActionResult Hall(HallViewModel model)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult NewTickets()
        {
            return PartialView();
        }

        public ActionResult Delete(int id)
        {
            this._repository.Delete(this._repository.GetById(id));
            this._unitOfWork.Save();
            return RedirectToAction("Backet", "Account");
        }
    }
}