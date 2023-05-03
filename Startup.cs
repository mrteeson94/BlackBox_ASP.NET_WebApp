using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(blackBox.Startup))]
namespace blackBox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
