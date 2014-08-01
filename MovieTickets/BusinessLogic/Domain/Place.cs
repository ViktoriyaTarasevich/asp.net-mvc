using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Domain
{
    public class Place : EntityBase
    {
        [Required]
        public byte Col { get; set; }

        [Required]
        public byte Row { get; set; }

        public int TicketCategoryId { get; set; }
    }
}