using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Domain
{
    public class Seance : EntityBase
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Required]
        public int FilmId { get; set; }

        [Required]
        public int TicketPriceId { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}