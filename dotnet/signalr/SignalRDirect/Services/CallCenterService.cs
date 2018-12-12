using System;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;

namespace SignalRDirect.Services
{
    public class CallCenterService : ICallCenterService
    {
        private readonly CallCenterContext _callCenterContext;
        public CallCenterService(
            CallCenterContext callCenterContext
        )
        {
            _callCenterContext = callCenterContext;
        }

        public async Task<bool> SaveUser(string name)
        {
            bool success = false;

            User user = new User{
                Name = name
            };
            
            try
            {
                await _callCenterContext.Users.AddAsync(user);
                await _callCenterContext.SaveChangesAsync();

                return success = true;
            }
            catch(Exception ex)
            {
                return success;

                throw ex;
            }
        }
    }
}