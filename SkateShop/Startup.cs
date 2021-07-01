using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkateShop.Startup))]
namespace SkateShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
