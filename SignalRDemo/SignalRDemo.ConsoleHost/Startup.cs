using Microsoft.AspNet.SignalR;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDemo.ConsoleHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapHubs(new HubConfiguration()
            {
                EnableCrossDomain = true,
                EnableDetailedErrors = true
            });
        }
    }
}
