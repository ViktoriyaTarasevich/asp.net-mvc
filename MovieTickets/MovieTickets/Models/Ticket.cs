using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
        public int? UserId { get; set; }
        

    }
}