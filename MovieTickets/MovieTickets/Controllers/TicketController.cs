using System;
using System.Web.Mvc;
using BusinessLogic;
using DataAccess.UnitOfWork;
using Microsoft.AspNet.Identity;
using MovieTickets.Context;
using MovieTickets.Entities.Models;
using MovieTickets.ViewModels;

namespace MovieTickets.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly IUnitOfWork<MovieTicketContext> _unitOfWork;

        public TicketController(IUnitOfWork<MovieTicketContext> uof)
        {
            _unitOfWork = uof;
            
        }

        // GET: Ticket

        [HttpGet]
        public ActionResult GetSeance(int filmId)
        {
            var model = new HallViewModel();
            var seanceRepository = _unitOfWork.GetRepository<Seance>();
            model.Seances = TicketControllerHelper.SetSeancesToSelectedListItems(seanceRepository.GetAll(), filmId);
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
            var repository = _unitOfWork.GetRepository<Ticket>();
            var model = new HallViewModel
            {
                SeanceId = idSeance,
                PlacesId = TicketControllerHelper.GetReservedPlacesForSeance(repository.GetAll(), idSeance)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Hall(int seanceId, string[] data)
        {
            if (data != null && seanceId > 0)
            {
                foreach (var place in data)
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
            var repository = _unitOfWork.GetRepository<Ticket>();
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