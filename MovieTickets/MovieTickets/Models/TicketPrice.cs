using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTickets.Models
{
    public class TicketPrice
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int TicketCategoryId { get; set; }
        public int SeanceId { get; set; }
    }
}