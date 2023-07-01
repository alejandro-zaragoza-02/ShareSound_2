using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asass.Startup))]
namespace asass
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
