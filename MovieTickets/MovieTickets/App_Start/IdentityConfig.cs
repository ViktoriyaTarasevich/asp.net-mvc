using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MovieTickets.Models;

namespace MovieTickets.App_Start
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<MovieTicketContext>()));
     
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
          
            manager.PasswordValidator = new PasswordValidator
            {
                //RequiredLength = 6,
                //RequireNonLetterOrDigit = true,
                //RequireDigit = true,
                //RequireLowercase = true,
                //RequireUppercase = true,
            };
          
            manager.EmailService = new EmailService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return Task.FromResult(0);
        }
    }

    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }
        public int RoleId { get; set; }
        public virtual ICollection<IpStory> IpStories { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; } 

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class MovieTicketContext : IdentityDbContext<ApplicationUser>
    {
       
        public MovieTicketContext()
            : base("MovieTicketContext", throwIfV1Schema: false)
        {
            
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