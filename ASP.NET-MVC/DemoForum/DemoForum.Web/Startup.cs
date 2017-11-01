using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoForum.Web.Startup))]
namespace DemoForum.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
