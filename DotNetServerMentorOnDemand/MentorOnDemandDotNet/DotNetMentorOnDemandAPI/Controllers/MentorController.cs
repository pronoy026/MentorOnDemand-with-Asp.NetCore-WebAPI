using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetMentorOnDemandAPI.Data;
using DotNetMentorOnDemandAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMentorOnDemandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        IMentorRepository repository;
        public MentorController(IMentorRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/Mentor
        [HttpGet("gettechs")]
        public IActionResult Get()
        {
            var techs = repository.GetTechnologies();
            if (!techs.Any())
            {
                return NoContent();
            }
            return Ok(techs);
        }

        // GET: api/Mentor/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mentor
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Mentor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
