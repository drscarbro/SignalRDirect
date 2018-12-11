using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRDirect.Services;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace SignalRDirect
{
    public class CallCenterHub : Hub
    {
        private readonly ICallCenterService _callCenterService;

        public CallCenterHub(ICallCenterService callCenterService)
        {
            _callCenterService = callCenterService;
        }
        public Task Send(string message)
        {
            return this.GetCallStatus(); //Clients.All.SendAsync("Send", message);
        }

        public void Call()
        {
            _callCenterService.Call();
        }

        public Task GetCallStatus()
        {
            string status = _callCenterService.GetCallStatus();

            return Clients.Caller.SendAsync("Send", status);
        }
    }
}