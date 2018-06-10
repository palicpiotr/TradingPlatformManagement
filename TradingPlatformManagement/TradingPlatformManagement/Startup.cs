using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TradingPlatformManagement.Startup))]
namespace TradingPlatformManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
