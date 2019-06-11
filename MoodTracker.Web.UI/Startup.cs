using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoodTracker.Web.UI.Startup))]
namespace MoodTracker.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
