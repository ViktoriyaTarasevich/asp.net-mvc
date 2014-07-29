using Microsoft.Owin;
using MovieTickets;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

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