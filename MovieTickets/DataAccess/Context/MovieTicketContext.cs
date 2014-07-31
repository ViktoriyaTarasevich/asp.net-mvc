using System.Data.Entity;
using DataAccess.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieTickets.Entities.Models;

namespace DataAccess.Context
{
    public class MovieTicketContext : IdentityDbContext<ApplicationUser>
    {
        public MovieTicketContext()
            : base("MovieTicketContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieTicketContext, Configuration>());
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TicketPrice> TicketPrices { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<IpStory> IpStories { get; set; }

        public static MovieTicketContext Create()
        {
            return new MovieTicketContext();
        }
    }
}