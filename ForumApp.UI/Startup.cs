using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ForumApp.UI.Startup))]
namespace ForumApp.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
