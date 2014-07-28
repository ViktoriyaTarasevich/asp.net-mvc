using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using Microsoft.AspNet.Identity;
using MovieTickets.App_Start;
using MovieTickets.Models;

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
        public ActionResult Hall()
        {
            var tickets = this._repository.GetAll();
            var array = (from ticket in tickets where ticket.ApplicationUserId != null select ticket.Id).ToList();
            ViewBag.ReservedSeats = array;
            return View();
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