using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Entities.Models
{
    public class Ticket : EntityBase
    {
        [Column(TypeName = "datetime2")]
        public DateTime DateTimeBuy { get; set; }

        public int SeanceId { get; set; }
        public int PlaceId { get; set; }
        public string ApplicationUserId { get; set; }
        public bool IsBought { get; set; }
    }
}