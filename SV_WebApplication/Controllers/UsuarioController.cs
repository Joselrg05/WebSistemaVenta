using Microsoft.AspNetCore.Mvc;

namespace SV_WebApplication.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
