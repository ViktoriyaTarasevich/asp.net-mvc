using System;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Domain
{
    public class Ticket : EntityBase
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTimeBuy { get; set; }

        public int SeanceId { get; set; }
        public int PlaceId { get; set; }
        public string ApplicationUserId { get; set; }
        public bool IsBought { get; set; }
    }
}