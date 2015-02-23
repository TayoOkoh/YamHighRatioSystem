using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YamHighRatioSys.Startup))]
namespace YamHighRatioSys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
