using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Domain
{
    public class TicketCategory : EntityBase
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int PriceCoef { get; set; }

        public virtual ICollection<Place> Places { get; set; }
    }
}