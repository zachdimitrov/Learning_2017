using Forum.Data;
using Forum.Data.Migrations;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(Forum.Web.Startup))]
namespace Forum.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumDbContext, Configuration>());
            ConfigureAuth(app);
        }
    }
}
