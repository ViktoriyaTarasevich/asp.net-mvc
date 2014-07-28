using System.Web.Mvc;

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