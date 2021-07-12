using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResourcePlacementAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Keys> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Keys>
    {
        private readonly Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var get = repository.Get();
            return Ok(get);
        }

        [HttpGet("{key}")]//tambahan buat bedain getnya
        public ActionResult Get(Keys key)
        {
            var get = repository.Get(key);
            if (get == null)
            {
                return Ok(get);
            }
            else
            {
                return Ok(get);
            }
        }

        [HttpPost]
        public ActionResult Post(Entity entity)
        {
            var insert = repository.Insert(entity);
            if (insert == 1)
            {
                return Ok(insert);
            }
            else
            {
                return BadRequest(insert);
            }
        }

        [HttpDelete("{key}")]
        public ActionResult Delete(Keys key)
        {
            var response = repository.Delete(key);
            if (key == null)
            {
                return BadRequest(response);
            }
            else
            {
                if (response == 1)
                {
                    return Ok(response);
                }
                else
                {
                    return Ok(response);
                }
            }
        }

        [HttpPut("{key}")]
        public ActionResult Update(Entity entity, Keys key)
        {
            var response = repository.Update(entity, key);
            if (key == null)
            {
                return BadRequest(response);
            }
            else
            {
                if (response == 1)
                {
                    return Ok(response);
                }
                else
                {
                    return Ok(response);
                }
            }
        }
    }
}
