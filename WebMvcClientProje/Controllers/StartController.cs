﻿using Microsoft.AspNetCore.Mvc;

namespace WebMvcClientProje.Controllers
{
    public class StartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
