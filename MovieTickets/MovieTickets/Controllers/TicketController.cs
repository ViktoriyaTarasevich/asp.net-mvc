using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using Microsoft.AspNet.Identity;
using MovieTickets.App_Start;
using MovieTickets.Context;
using MovieTickets.Entities.Models;
using MovieTickets.ViewModels;

namespace MovieTickets.Controllers
{
    public class TicketController : Controller
    {
        private readonly IRepository<Ticket> _repository;
        private readonly IUnitOfWork<MovieTicketContext> _unitOfWork;

        public TicketController(IUnitOfWork<MovieTicketContext> uof)
        {
            _unitOfWork = uof;
            _repository = _unitOfWork.GetRepository<Ticket>();
        }

        // GET: Ticket

        [HttpGet]
        public ActionResult GetSeance(int idFilm)
        {
            var model = new HallViewModel();
            IRepository<Seance> seanceRepository = _unitOfWork.GetRepository<Seance>();
            IEnumerable<Seance> seances = seanceRepository.GetAll();
            model.Seances = new List<SelectListItem>();
            foreach (Seance seance in seances)
            {
                if (seance.FilmId == idFilm)
                {
                    model.Seances.Add(new SelectListItem
                        {
                            Text = (seance.Date.ToShortDateString() + " : " + seance.Time.ToShortTimeString()),
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
            ViewBag.SeanceId = idSeance;
            model.SeanceId = idSeance;
            IEnumerable<Ticket> tickets = _repository.GetAll();
            List<Ticket> array = (from ticket in tickets where ticket.ApplicationUserId != null select ticket).ToList();
            model.PlacesId = new List<int>();
            foreach (Ticket i in array)
            {
                model.PlacesId.Add(i.PlaceId);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Hall(int seanceId, string[] data)
        {
            string[] datas = data;
            foreach (var s in datas)
            {
                _unitOfWork.GetRepository<Ticket>().Insert(new Ticket
                {
                    ApplicationUserId = User.Identity.GetUserId(),
                    DateTimeBuy = DateTime.Now,
                    PlaceId = Int32.Parse(s),
                    SeanceId = seanceId
                });
            }
            
            _unitOfWork.Save();
            return View("Hall",new{idSeance = seanceId});
        }

        public ActionResult NewTickets()
        {
            return PartialView();
        }

        public ActionResult Delete(int id)
        {
            _repository.Delete(_repository.GetById(id));
            _unitOfWork.Save();
            return RedirectToAction("Backet", "Account");
        }
    }
}