using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Domain
{
    public class TicketPrice : EntityBase
    {
        [Required]
        public int Price { get; set; }
    }
}