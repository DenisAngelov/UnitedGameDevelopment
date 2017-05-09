using Microsoft.Owin;
using UnitedGameDevelopment.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace UnitedGameDevelopment.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
