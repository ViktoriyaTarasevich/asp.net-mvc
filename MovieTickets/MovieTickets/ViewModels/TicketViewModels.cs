using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MovieTickets.ViewModels
{
    public class TicketViewModels
    {
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Film { get; set; }

        [Required]
        public int Row { get; set; }

        [Required]
        public int Column { get; set; }

        [Required]
        public int Price { get; set; }
    }
}