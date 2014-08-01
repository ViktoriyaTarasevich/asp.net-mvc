using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Domain
{
    public class TicketCategory : EntityBase
    {
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        public int PriceCoef { get; set; }

        public virtual ICollection<Place> Places { get; set; }
    }
}