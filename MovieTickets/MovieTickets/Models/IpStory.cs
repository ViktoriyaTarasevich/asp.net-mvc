using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieTickets.Models
{
    public class IpStory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        
        public string Ip { get; set; }

        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public int AspNetUserId { get; set; }
    }
}