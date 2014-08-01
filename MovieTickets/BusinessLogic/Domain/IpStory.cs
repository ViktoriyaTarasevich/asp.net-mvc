using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Domain
{
    public class IpStory : EntityBase
    {
        [Required]
        [RegularExpression(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b)")]
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