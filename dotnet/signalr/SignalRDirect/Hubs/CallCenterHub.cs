using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRDirect
{
    public class CallCenterHub : Hub
    {
        public Task Send(string message)
        {
            return Clients.All.SendAsync("Send", message);
        }
    }
}