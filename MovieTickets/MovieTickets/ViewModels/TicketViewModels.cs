using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MovieTickets.ViewModels
{
    public class TicketViewModels
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Film { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Price { get; set; }

        

    }
}