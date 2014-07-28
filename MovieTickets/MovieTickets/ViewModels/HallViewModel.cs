﻿using System.Collections.Generic;
using System.Web.Mvc;
using MovieTickets.Models;

namespace MovieTickets.ViewModels
{
    public class HallViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public List<int> PlacesId  { get; set; }
        public List<SelectListItem> Seances { get; set; } 


    }
}