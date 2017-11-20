using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineFlightBookingSystem.Startup))]
namespace OnlineFlightBookingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
