using System.ComponentModel.DataAnnotations;

namespace MovieTickets.ViewModels
{
    public class LogInViewModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string SurnName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}