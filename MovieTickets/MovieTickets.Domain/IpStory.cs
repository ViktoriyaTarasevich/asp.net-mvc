using System;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Domain
{
    public class IpStory : EntityBase
    {
        [Required]
        public string Ip { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public string ApplicationUserId { get; set; }
    }
}