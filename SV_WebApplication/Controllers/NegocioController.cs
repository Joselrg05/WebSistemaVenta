﻿using Microsoft.AspNetCore.Mvc;

namespace SV_WebApplication.Controllers
{
    public class NegocioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
