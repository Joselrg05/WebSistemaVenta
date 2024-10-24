using Microsoft.AspNetCore.Mvc;

namespace SV_WebApplication.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
