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
using static Client.Enums.Enums;

namespace Client.Controllers
{
    public class Add2Controller : BaseController<Employees, Add2Repository, int>
    {
        private readonly Add2Repository repository;
        public Add2Controller(Add2Repository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            Alert("Welcome!", "On ADD 2 Page", NotificationType.success);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> ShowDetailProject()
        {
            var result = await repository.ShowDetailProjects();
            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetListParticipant()
        {
            var result = await repository.GetAllParticipant();
            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ProjectPlotting()
        {
            //Alert("Welcome!", "On Placement Page", NotificationType.success);
            return View();
        }

        [HttpGet("Add2/GetParticipantId/{participantId}")]
        public int GetParticipantId(int participantId)
        {
            var participantIdString = participantId.ToString();
            HttpContext.Session.SetString("participantId", participantIdString);
            return participantId;
        }

        public RedirectToActionResult ChooseParticipant(ProjectPlottingVM projectPlotting)
        {
            var participantId = Int32.Parse(HttpContext.Session.GetString("participantId"));
            var result = repository.Ploting(projectPlotting, participantId);
            if (result == System.Net.HttpStatusCode.OK)
            {
                Alert("Great!", "Participant Plotting Succeed!", NotificationType.success);
                return RedirectToAction("projectplotting", "add2");
            }
            else
            {
                Alert("Oops!", "Participant Plotting Failed!", NotificationType.error);
                return RedirectToAction("projectplotting", "add2");
            }
        }
    }
}
