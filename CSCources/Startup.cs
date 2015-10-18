using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSCources.Startup))]
namespace CSCources
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
