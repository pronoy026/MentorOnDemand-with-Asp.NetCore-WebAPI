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
        //for checkin' if mentor skill already exists
        [HttpPost("mentorskillexists")]
        public IActionResult MentorSkillExists([FromBody] MentorSkill mentorSkill)
        {
            var result = repository.MentorSkillExists(mentorSkill.TechId, mentorSkill.MentorEmail);
            if (result)
            {
                return BadRequest("The Course is already created by you!");
            }
            return Ok();
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

        [HttpGet("getappliedcourses/{email}")]
        public IActionResult GetAppliedCourses(string email)
        {
            var courses = repository.GetAppliedCourses(email);
            return Ok(courses);
        }

        [HttpGet("getregisteredcourses/{email}")]
        public IActionResult GetRegisteredCourses(string email)
        {
            var courses = repository.GetRegisteredCourses(email);
            return Ok(courses);
        }

        [HttpGet("getcompletedcourses/{email}")]
        public IActionResult GetCompletedCourses(string email)
        {
            var courses = repository.GetCompletedCourses(email);
            return Ok(courses);
        }

        [HttpGet("getrejectedcourses/{email}")]
        public IActionResult GetRejectedCourses(string email)
        {
            var courses = repository.GetRejectedCourses(email);
            return Ok(courses);
        }


        [HttpPost("acceptcourse")]
        public IActionResult AcceptCourse([FromBody] Course course)
        {
            var result = repository.AcceptCourse(course);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("rejectcourse")]
        public IActionResult RejectCourse([FromBody] Course course)
        {
            var result = repository.RejectCourse(course);
            if (result)
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
