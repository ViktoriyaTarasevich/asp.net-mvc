using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Presentation.ViewModels
{
    public class SeanceViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        public DateTime Time { get; set; }

        [Required]
        public int Price { get; set; }
    }
}