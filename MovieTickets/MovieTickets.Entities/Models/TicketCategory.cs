using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Entities.Models
{
    public class TicketCategory : EntityBase
    {
        [Required]
        public string Title { get; set; }
        public int PriceCoef { get; set; }
        public virtual ICollection<Place> Places { get; set; }
    }
}