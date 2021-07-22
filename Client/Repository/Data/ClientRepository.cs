﻿using Client.Base;
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
    public class ClientRepository : GeneralRepository<Projects, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public ClientRepository(Address address, string request = "project/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public HttpStatusCode AddProject(AddProjectVM entity, int customerId)
        {
            entity.CustomerUsersId = customerId;

            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            //var gg = content.ReadAsByteArrayAsync();

            var result = httpClient.PostAsync(address.link + "project/addproject/", content).Result;
            return result.StatusCode;
        }
    }
}
