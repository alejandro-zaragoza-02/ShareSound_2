using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShareSound_2_Front.Startup))]
namespace ShareSound_2_Front
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
