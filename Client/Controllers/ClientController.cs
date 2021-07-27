using Client.Base;
using Client.Models;
using Client.Repository;
using Client.Repository.Data;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class ClientController : BaseController<Projects, ClientRepository, int>
    {
        private readonly ClientRepository repository;
        public ClientController(ClientRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            var message = HttpContext.Session.GetString("message");
            if (message == "Berhasil")
            {
                ViewBag.Message = string.Format("Berhasil");
                return View();
            }
            else if (message == "Gagal")
            {
                ViewBag.Message = string.Format("Gagal");
                return View();
            }
            else
            {
                return View();
            }
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
                HttpContext.Session.SetString("message", "Berhasil");
                return RedirectToAction("index", "client");
            }
            else
            {
                HttpContext.Session.SetString("message", "Gagal");
                return RedirectToAction("index", "client");
            }
        }

        public RedirectToActionResult ChooseParticipant(ChooseParticipantVM chooseParticipant)
        {
            var participantId = Int32.Parse(HttpContext.Session.GetString("participantId"));
            var result = repository.ChooseParticipant(chooseParticipant, participantId);
            if (result == System.Net.HttpStatusCode.OK)
            {
                HttpContext.Session.SetString("message", "Berhasil");
                return RedirectToAction("index", "client");
            }
            else
            {
                HttpContext.Session.SetString("message", "Gagal");
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

        [HttpGet("Client/AllSkillParticipant/{nik}")]
        public async Task<JsonResult> AllSkillParticipant(int nik)
        {
            var nikString = nik.ToString();
            HttpContext.Session.SetString("participantId", nikString);
            var result = await repository.AllSkillParticipant(nik);
            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
