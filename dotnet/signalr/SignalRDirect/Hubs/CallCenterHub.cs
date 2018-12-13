using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRDirect.Services;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using System.Collections.Generic;
using System.Linq;

namespace SignalRDirect
{
    public class CallCenterHub : Hub
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>();
        private readonly ICallCenterService _callCenterService;

        public CallCenterHub(
            ICallCenterService callCenterService
        )
        {
            _callCenterService = callCenterService;
        }

        public Task Send(string message)
        {
            var clients = this.Clients;
            return Clients.All.SendAsync("Send", message);
        }

        public Task Join(string username)
        {
            users[username] = this.Context.ConnectionId;

            var userKey = users.Where(u => u.Key.Equals(username)).Select(u => u.Key);

            return Clients.AllExcept(this.Context.ConnectionId).SendAsync("AddUserList", userKey);
        }

        public Task TakeBlock(string username)
        {
            try{
                string s = "You been took!";
                return Clients.Client(users[username]).SendAsync("TakeBlock", s);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}