using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRDemo.ConsoleHost
{
    [HubName("Lounge")]
    public class LoungeHub : Hub
    {
        public void PingHello(string param)
        {
            Clients.All.pongHello("You wrote: " + param);
        }

    }
}