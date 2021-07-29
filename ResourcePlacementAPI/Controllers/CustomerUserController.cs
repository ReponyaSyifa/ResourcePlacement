using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourcePlacementAPI.Base;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.Repositories.Data;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerUserController : BaseController<CustomerUsers, CustomerUserRepository, int>
    {
        private CustomerUserRepository repository;
        public CustomerUserController(CustomerUserRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpPost("ChooseParticipant/{participantId}")]
        public ActionResult ChooseParticipant(ChooseParticipantVM chooseParticipantVM, int participantId)
        {
            var choose = repository.ChooseParticipant(chooseParticipantVM, participantId);
            if (choose == 0)
            {
                return BadRequest(choose);
            }
            else if(choose == 1)
            {
                return Ok(choose);
            }
            else
            {
                return BadRequest(choose);
            }
        }

        // List participant yang di akan tampil di User, yang telah di rekomendasi oleh ADD2
        [HttpGet("AllChoosedParticipants/{customerUserId}")]
        public ActionResult AllChoosedParticipants(int customerUserId)
        {
            var get = repository.AllChoosedParticipants(customerUserId);
            return Ok(get);
        }
    }
}
