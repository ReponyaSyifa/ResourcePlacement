using Client.Base;
using Client.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Repository.Data
{
    public class Add2Repository : GeneralRepository<Employees, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;

        public Add2Repository(Address address, string request = "employee/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<ShowDetailProjectVM>> ShowDetailProjects()
        {
            List<ShowDetailProjectVM> entities = new List<ShowDetailProjectVM>();

            using (var response = await httpClient.GetAsync("project/showdetailproject/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<ShowDetailProjectVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<GetAllParticipant>> GetAllParticipant()
        {
            List<GetAllParticipant> entities = new List<GetAllParticipant>();

            using (var response = await httpClient.GetAsync("participant/GetListParticipant/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<GetAllParticipant>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<ShowSkillVM>> AllSkillProject(int projectId)
        {
            List<ShowSkillVM> entities = new List<ShowSkillVM>();

            using (var response = await httpClient.GetAsync("project/showskillprojects/" + projectId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<ShowSkillVM>>(apiResponse);
            }
            return entities;
        }

        public HttpStatusCode Ploting(ProjectPlottingVM projectPlotting, int participantId)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(projectPlotting), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + "employee/ProjectPlotting/" + participantId, content).Result;
            return result.StatusCode;
        }
    }
}
