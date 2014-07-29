using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Entities.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateTimeBuy { get; set; }
        public int SeanceId { get; set; }
        public int PlaceId { get; set; }
        public string ApplicationUserId { get; set; }
        

    }
}