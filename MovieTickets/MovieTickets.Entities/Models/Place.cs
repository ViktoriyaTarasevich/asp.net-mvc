namespace MovieTickets.Entities.Models
{
    public class Place : EntityBase
    {
        public byte Col { get; set; }
        public byte Row { get; set; }
        public int TicketCategoryId { get; set; }
    }
}