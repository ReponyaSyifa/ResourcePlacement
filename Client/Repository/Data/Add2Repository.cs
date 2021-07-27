using Client.Base;
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
    }
}
