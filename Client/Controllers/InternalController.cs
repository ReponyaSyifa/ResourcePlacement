using Client.Base;
using Client.Models;
using Client.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResourcePlacementAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    //[Authorize]
    public class InternalController : BaseController<Participants, ParticipantRepository, int>
    {
        private readonly ParticipantRepository repository;
        public InternalController(ParticipantRepository repository) : base(repository)
        {
            this.repository = repository;
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
