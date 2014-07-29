using System.Collections.Generic;
using System.Web.Mvc;

namespace MovieTickets.ViewModels
{
    public class HallViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int SeanceId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public List<int> PlacesId  { get; set; }

        public List<SelectListItem> Seances { get; set; } 


    }
}