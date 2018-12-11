using System;
using Microsoft.AspNetCore.Mvc;
using SignalRDirect.Services;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SignalRDirect
{
    public class CallCenterController : Controller
    {
        private readonly ICallCenterService _callCenterService;

        public CallCenterController(ICallCenterService callCenterService)
        {
            _callCenterService = callCenterService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public void Dial()
        {
           _callCenterService.Call();
        }
    }
}