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
using static Client.Enums.Enums;

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
            //Alert("Welcome!", "On Clinet Page", NotificationType.success);
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
                Alert("Nice!", "Add New Project Succeed!", NotificationType.success);
                var reload = RedirectToAction("index", "client");
                return reload;
            }
            else
            {
                Alert("Oh Snap!", "Add New Project Failed!", NotificationType.error);
                var reload = RedirectToAction("index", "client");
                return reload;
            }
        }

        public RedirectToActionResult ChooseParticipant(ChooseParticipantVM chooseParticipant)
        {
            var participantId = Int32.Parse(HttpContext.Session.GetString("participantId"));
            var result = repository.ChooseParticipant(chooseParticipant, participantId);
            if (result == System.Net.HttpStatusCode.OK)
            {
                Alert("Nice!", "Participant Choosed!", NotificationType.success);
                var reload = RedirectToAction("index", "client");
                return reload;
            }
            else if (result == System.Net.HttpStatusCode.BadRequest)
            {
                Alert("Nice!", "Participant Rejected!", NotificationType.warning);
                var reload = RedirectToAction("index", "client");
                return reload;
            }
            else
            {
                Alert("Oh Snap!", "Choose Participant Failed!", NotificationType.error);
                var reload = RedirectToAction("index", "client");
                return reload;
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
