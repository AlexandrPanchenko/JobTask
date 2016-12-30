using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InputReplacer.Startup))]
namespace InputReplacer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
