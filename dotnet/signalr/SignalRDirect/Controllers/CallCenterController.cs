using Microsoft.AspNetCore.Mvc;

namespace SignalRDirect
{
    public class CallCenterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}