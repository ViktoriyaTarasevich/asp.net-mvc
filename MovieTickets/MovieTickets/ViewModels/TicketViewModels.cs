using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTickets.ViewModels
{
    public class TicketViewModels
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public bool IsLorry { get; set; }
        public bool IsVacant { get; set; }
        public bool IsSelected { get; set; }
    }
}