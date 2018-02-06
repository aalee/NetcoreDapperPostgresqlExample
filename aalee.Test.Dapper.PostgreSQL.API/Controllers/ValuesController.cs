﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aalee.Test.Dapper.PostgreSQL.Repository;
using aalee.Test.Dapper.PostgreSQL.Contracts.Repository;

namespace aalee.Test.Dapper.PostgreSQL.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        public IAdminAlee AdminAlee { get; set; }

        public ValuesController(IAdminAlee adminAlee)
        {
            this.AdminAlee = adminAlee;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", AdminAlee.getDate() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}