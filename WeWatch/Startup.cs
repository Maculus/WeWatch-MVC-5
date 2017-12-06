using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeWatch.Startup))]
namespace WeWatch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
