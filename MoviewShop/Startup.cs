using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviewShop.Startup))]
namespace MoviewShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
