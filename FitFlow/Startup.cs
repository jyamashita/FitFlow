using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitFlow.Startup))]
namespace FitFlow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
