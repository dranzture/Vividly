using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vividly.Startup))]
namespace Vividly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
