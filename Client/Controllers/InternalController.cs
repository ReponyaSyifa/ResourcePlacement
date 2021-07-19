using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    //[Authorize]
    public class InternalController : Controller
    {
        private readonly ILogger<InternalController> _logger;

        public InternalController(ILogger<InternalController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() //landing pange
        {
            return View();
        }

        public IActionResult Login() //landing pange
        {
            return View();
        }
        public IActionResult Internal() //landing pange
        {
            return View();
        }

        public IActionResult ADD2() //landing pange
        {
            return View();
        }

        public IActionResult Trainer() //landing pange
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
