﻿using Microsoft.AspNetCore.Mvc;

namespace MaklerSamxal.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Agents()
        {
            return View();
        }

    }
}