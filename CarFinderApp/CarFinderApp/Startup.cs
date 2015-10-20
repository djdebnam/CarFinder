using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarFinderApp.Startup))]
namespace CarFinderApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
