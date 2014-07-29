using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Entities.Models
{
    public class Seance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        public DateTime Time { get; set; }
        public int FilmId { get; set; }

        public int TicketPriceId { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        

        
    }
}