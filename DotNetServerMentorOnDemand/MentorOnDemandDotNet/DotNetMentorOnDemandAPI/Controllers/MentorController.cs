using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetMentorOnDemandAPI.Data;
using DotNetMentorOnDemandAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMentorOnDemandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpPost("creatementorskill")]
        public IActionResult Post([FromBody] MentorSkill mentorSkill)
        {
            var result = repository.CreateSkill(mentorSkill);
            if(result)
            {
                return Ok();
            }
            return BadRequest();
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
