using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Entities.Models
{
    public class IpStory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        
        public string Ip { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Time { get; set; }

        public string ApplicationUserId { get; set; }
    }
}