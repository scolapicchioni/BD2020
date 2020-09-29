using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMvcCore.SignalRDemo
{
    public class SimoHub : Hub
    {
        public async Task TheServerMethod(string user, string message)
        {
            await Clients.All.SendAsync("TheClientMethod", user, message);
        }
    }
}
