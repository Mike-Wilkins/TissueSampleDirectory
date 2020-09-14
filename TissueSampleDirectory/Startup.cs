using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TissueSampleDirectory.Startup))]
namespace TissueSampleDirectory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
