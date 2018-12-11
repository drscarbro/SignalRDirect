using System;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.AspNetCore.SignalR;

namespace SignalRDirect.Services
{
    public class CallCenterService : ICallCenterService
    {
        public void Call()
        {
           const string accountSid = "AC286293e816ea992ee963057932ba9d36";
           const string authToken = "d2e231ff485c521f72c60adac9ef4c94";
            Twilio.TwilioClient.Init(accountSid, authToken);

           var to = new PhoneNumber("+14797900899");
           var from = new PhoneNumber("+14798884154");
           var call = CallResource.Create(to, from,
            url: new Uri("http://demo.twilio.com/docs/voice.xml"));

           Console.WriteLine(call.Sid);
        }

        public string GetCallStatus()
        {
            string status = "Status";

            return status;
        }
    }
}