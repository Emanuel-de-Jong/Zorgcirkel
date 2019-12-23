using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zorgcirckel.Startup))]
namespace Zorgcirckel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
