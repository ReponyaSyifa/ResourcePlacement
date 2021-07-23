using Client.Base;
using Client.Models;
using Client.Repository;
using Client.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class ClientController : BaseController<Projects, ClientRepository, int>
    {
        private readonly ClientRepository repository;
        public ClientController(ClientRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public RedirectToActionResult AddProject(AddProjectVM entity)
        {
            var id = (HttpContext.Session.GetString("id"));
            var gg = Int32.Parse(id);
            var result = repository.AddProject(entity, gg);
            if (result == System.Net.HttpStatusCode.OK)
            {
                ViewBag.Message = String.Format("Berhasil");
                return RedirectToAction("index", "client");
            }
            else
            {
                ViewBag.Message = String.Format("Gagal");
                return RedirectToAction("index", "client");
            }
        }

        [HttpGet]
        public async Task<JsonResult> AllChoosedParticipant()
        {
            var id = (HttpContext.Session.GetString("id"));
            var gg = Int32.Parse(id);
            var result = await repository.AllChoosedParticipant(gg);
            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
