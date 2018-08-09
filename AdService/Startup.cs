using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdService.Startup))]
namespace AdService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
