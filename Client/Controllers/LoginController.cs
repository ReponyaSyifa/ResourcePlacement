using Client.Models;
using Client.Repository.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginRepository repository;

        public LoginController(LoginRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Auth(LoginVM login)
        {
            var jwToken = await repository.Auth(login);
            if (jwToken == null)
            {
                return RedirectToAction("index");
            }

            HttpContext.Session.SetString("Jwt", jwToken.Token);
            HttpContext.Session.SetString("role", repository.GetRole(jwToken.Token));
            HttpContext.Session.SetString("id", repository.GetId(jwToken.Token));

            var role = HttpContext.Session.GetString("role");
            if (role == "Trainer")
            {
                return RedirectToAction("Trainer", "internal");
            }

            else if (role == "ADD 2")
            {
                return RedirectToAction("ADD2", "internal");
            }

            else
            {
                //return RedirectToAction("dashboard", "eksternal");
                return RedirectToAction("index", "client");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
           // await HttpContext.SignOutAsync();
            return RedirectToAction("index", "home");
        }

    }
}
