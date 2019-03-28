using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechnicalService.Startup))]
namespace TechnicalService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
