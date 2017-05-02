using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Baja.Web.Startup))]
namespace Baja.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
