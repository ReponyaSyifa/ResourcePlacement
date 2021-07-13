using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourcePlacementAPI.Base;
using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Models;
using ResourcePlacementAPI.Repositories.Data;
using ResourcePlacementAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Accounts, AccountRepository, int>
    {
        private readonly AccountRepository repository;
        private readonly MyContext myContext;

        public AccountController(AccountRepository repository, MyContext myContext) : base(repository)
        {
            this.myContext = myContext;
            this.repository = repository;
        }

        [HttpPost("/API/Account/Login")]
        public  ActionResult Login(LoginVM loginVM)
        {
            int login = repository.Login(loginVM);
            switch (login)
            {
                case 1:
                    return BadRequest();
                case 2:
                    return Ok();
                default:
                    return BadRequest();
            }
        }

    }
}
