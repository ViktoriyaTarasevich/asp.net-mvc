using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Password { get; set; }
        
        public int RoleId { get; set; }

        public virtual ICollection<IpStory> IpStories { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; } 
    }
}