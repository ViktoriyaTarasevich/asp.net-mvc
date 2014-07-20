using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieTickets.ViewModels
{
    public class LogInViewModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}