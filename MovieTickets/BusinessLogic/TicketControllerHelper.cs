﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using MovieTickets.Entities.Models;

namespace BusinessLogic
{
    public static class TicketControllerHelper
    {
        public static List<SelectListItem> SetSeancesToSelectedListItems(IEnumerable<Seance> seances, int filmId)
        {
            var result  = (from seance in seances
                where seance.FilmId == filmId
                select new SelectListItem
                {
                    Text = (seance.Date.ToShortDateString() + " | " + seance.Time.ToShortTimeString()), Value = seance.Id.ToString(CultureInfo.InvariantCulture)
                }).ToList();
            return result;
        }

        public static List<int> GetReservedPlacesForSeance(IEnumerable<Ticket> tickets, int seanceId)
        {
            var result = (from ticket in tickets
                where ticket.ApplicationUserId != null && ticket.SeanceId == seanceId
                select ticket.PlaceId).ToList();
            return result;
        }

    }
}
