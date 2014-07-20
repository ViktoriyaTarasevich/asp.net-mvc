using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieTickets.Models
{
    public class MovieTicketContext : DbContext
    {
        public MovieTicketContext()
            : base("MovieTicketContext")
        {
            
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TicketPrice> TicketPrices { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<IpStory> IpStories { get; set; }  
    }
}