using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrueDating.Startup))]
namespace TrueDating
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
