using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieTickets.ViewModels
{
    public class SeanceViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        public DateTime Time { get; set; }
        [Required]
        public int Price { get; set; }
    }
}