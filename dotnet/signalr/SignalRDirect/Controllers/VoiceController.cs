using System;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace SignalRDirect
{
    public class VoiceController : TwilioController
    {
        public IActionResult Index()
        {
            var response = new VoiceResponse();
            response.Say("Thank you for calling! Have a great day.");

            Console.WriteLine("Response is: " + response);

            return TwiML(response);
        }
    }
}