using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Domain
{
    public class ApplicationUser 
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SurName { get; set; }

        public int RoleId { get; set; }
        public virtual ICollection<IpStory> IpStories { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}