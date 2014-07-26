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
            List<int> array = new List<int>();
            foreach (var ticket in tickets)
            {
                if (ticket.ApplicationUserId != null)
                {
                    array.Add(ticket.Id);
                }
            }
            ViewBag.ReservedSeats = array;
            ViewBag.CurrentUser = User.Identity.GetUserId();
            return View();
        }
    }
}