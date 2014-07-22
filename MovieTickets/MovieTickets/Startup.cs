using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MovieTickets.Startup))]
namespace MovieTickets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}