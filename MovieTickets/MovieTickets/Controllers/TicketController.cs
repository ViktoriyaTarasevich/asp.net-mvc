using System;
using System.Web.Mvc;
using BusinessLogic;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using Microsoft.AspNet.Identity;
using MovieTickets.Entities.Models;
using MovieTickets.ViewModels;

namespace MovieTickets.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketController(IUnitOfWork uof)
        {
            _unitOfWork = uof;
        }

        // GET: Ticket

        [HttpGet]
        public ActionResult GetSeance(int filmId)
        {
            var model = new HallViewModel();
            IRepository<Seance> seanceRepository = _unitOfWork.GetRepository<Seance>();
            model.Seances = TicketHelper.SetSeancesToSelectedListItems(seanceRepository.GetAll(), filmId);
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
            var ticketRepository = _unitOfWork.GetRepository<Ticket>();
            var seance = _unitOfWork.GetRepository<Seance>().GetById(idSeance);
            var model = new HallViewModel
                {
                    SeanceId = idSeance,
                    PlacesId = TicketHelper.GetReservedPlacesForSeance(ticketRepository.GetAll(), idSeance),
                    Price = TicketHelper.GetPriceForSeance(seance,_unitOfWork.GetRepository<TicketPrice>().GetAll())
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Hall(int seanceId, string[] data)
        {
            if (data != null && seanceId > 0)
            {
                foreach (string place in data)
                {
                    _unitOfWork.GetRepository<Ticket>().Insert(new Ticket
                        {
                            ApplicationUserId = User.Identity.GetUserId(),
                            DateTimeBuy = DateTime.Now,
                            PlaceId = Int32.Parse(place),
                            SeanceId = seanceId,
                            IsBought = false
                        });
                }
                _unitOfWork.Save();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            IRepository<Ticket> repository = _unitOfWork.GetRepository<Ticket>();
            repository.Delete(repository.GetById(id));
            _unitOfWork.Save();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult NewTickets()
        {
            return PartialView();
        }
    }
}