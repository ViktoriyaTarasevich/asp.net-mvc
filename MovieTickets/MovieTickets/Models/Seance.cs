using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Models
{
    public class Seance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public int FilmId { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<TicketPrice> TicketPrices { get; set; }
    }
}