using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateTimeBuy { get; set; }
        public int SeanceId { get; set; }
        public int PlaceId { get; set; }
        public int? AspNetUserId { get; set; }
        

    }
}