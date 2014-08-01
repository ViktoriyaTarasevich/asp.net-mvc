using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using DataAccess.Repository;
using MovieTickets.Entities.Models;
using MovieTickets.Presentation.ViewModels;
using Film = BusinessLogic.Domain.Film;
using Place = BusinessLogic.Domain.Place;
using Seance = BusinessLogic.Domain.Seance;
using Ticket = BusinessLogic.Domain.Ticket;
using TicketCategory = BusinessLogic.Domain.TicketCategory;
using TicketPrice = BusinessLogic.Domain.TicketPrice;

namespace BusinessLogic
{
    public static class TicketHelper
    {
        public static List<SelectListItem> SetSeancesToSelectedListItems(IEnumerable<Seance> seances, int filmId)
        {
            List<SelectListItem> result = (from seance in seances
                                           where seance.FilmId == filmId
                                           select new SelectListItem
                                               {
                                                   Text =
                                                       (seance.Date.ToShortDateString() + " | " +
                                                        seance.Time.ToShortTimeString()),
                                                   Value = seance.Id.ToString(CultureInfo.InvariantCulture)
                                               }).ToList();
            return result;
        }

        public static List<int> GetReservedPlacesForSeance(IEnumerable<Ticket> tickets, int seanceId)
        {
            var list = new List<Ticket>(tickets);
            List<int> result = (from ticket in list
                                where ticket.SeanceId == seanceId && ticket.IsBought
                                select ticket.PlaceId).ToList();
            return result;
        }

        public static bool IsTicketPriceIdInDataBase(IEnumerable<TicketPrice> ticketsPrice, int ticketPrice)
        {
            return ticketsPrice.Any(x => x.Price == ticketPrice);
        }

        public static List<TicketViewModels> GetInformationForBascket(IRepository<TicketPrice> ticketsPrice,
                                                                      IRepository<TicketCategory> ticketCategories,
                                                                      List<Ticket> tickets, IRepository<Film> films,
                                                                      IRepository<Seance> seances,
                                                                      IRepository<Place> places)
        {
            List<TicketViewModels> ticketsModel = (from ticket in tickets
                                                   where ticket.IsBought == false
                                                   let place = places.GetById(ticket.PlaceId)
                                                   let seance = seances.GetById(ticket.SeanceId)
                                                   let film = films.GetById(seance.FilmId)
                                                   let price = ticketsPrice.GetById(seance.TicketPriceId)
                                                   let category =
                                                       ticketCategories.GetById(place.TicketCategoryId)
                                                   select new TicketViewModels
                                                       {
                                                           Id = ticket.Id,
                                                           Row = place.Row,
                                                           Column = place.Col,
                                                           Film = film.Title,
                                                           Price = price.Price*category.PriceCoef
                                                       }).ToList();
            return ticketsModel;
        }
    }
}