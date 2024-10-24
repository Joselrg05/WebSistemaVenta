using Microsoft.AspNetCore.Mvc;

namespace SV_WebApplication.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
