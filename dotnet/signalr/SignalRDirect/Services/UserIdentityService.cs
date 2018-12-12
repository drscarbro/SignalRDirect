using Microsoft.AspNetCore.SignalR;

namespace SignalRDirect.Services
{
    public class UserIdentityService : IUserIdentityService
    {
        public string GetUserId(HubConnectionContext hubConnectionContext)
        {
            var identity = hubConnectionContext.User.Identity.Name;

            return identity;
        }
    }
}