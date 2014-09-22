using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRDemo.Web.Startup))]
namespace SignalRDemo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
