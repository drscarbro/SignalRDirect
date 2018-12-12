using System;
using System.Security.Claims;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDirect.Services;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SignalRDirect
{
    [Authorize]
    public class CallCenterController : Controller
    {
        private readonly ICallCenterService _callCenterService;

        private IHubContext<CallCenterHub> _hubContext;

        public CallCenterController(
            ICallCenterService callCenterService,
            IHubContext<CallCenterHub> hubContext
        )
        {
            _hubContext = hubContext;
            _callCenterService = callCenterService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return RedirectToAction(nameof(Index));
            }

            var identity = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, name),
                },
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal
            );

            await _callCenterService.SaveUser(name);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Console()
        {
            return View();
        }
    }
}