using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Domain
{
    public class Ticket : EntityBase
    {
        [DataType(DataType.DateTime)]
        public DateTime DateTimeBuy { get; set; }

        public int SeanceId { get; set; }

        public int PlaceId { get; set; }

        public string ApplicationUserId { get; set; }

        [Required]
        public bool IsBought { get; set; }
    }
}