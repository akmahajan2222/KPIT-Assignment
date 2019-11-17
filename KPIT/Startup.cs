using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KPIT.Startup))]
namespace KPIT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
