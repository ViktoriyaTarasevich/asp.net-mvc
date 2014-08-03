using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Domain
{
    public class TicketPrice : EntityBase
    {
        [Required]
        public int Price { get; set; }
    }
}