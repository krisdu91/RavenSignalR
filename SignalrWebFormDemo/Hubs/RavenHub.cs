using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalrWebFormDemo.Hubs
{
    public class RavenHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            //Clients.All.Output(name, message);
            var context = GlobalHost.ConnectionManager.GetHubContext<RavenHub>();
            context.Clients.All.Output(name, message);
        }
    }
}