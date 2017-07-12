using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeleiteVenezolano.MVC.Startup))]
namespace DeleiteVenezolano.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
