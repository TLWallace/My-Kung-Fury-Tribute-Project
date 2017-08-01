using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNETFP_KungFuryNonFanSite.Startup))]
namespace ASPNETFP_KungFuryNonFanSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
