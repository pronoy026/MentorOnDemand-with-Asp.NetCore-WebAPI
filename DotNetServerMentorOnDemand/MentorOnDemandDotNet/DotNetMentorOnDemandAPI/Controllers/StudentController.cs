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
    public class StudentController : ControllerBase
    {

        IStudentRepository repository;
        public StudentController(IStudentRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/Student
        [HttpPost("checkcourse")]
        public IActionResult CheckCourse([FromBody] Course course)
        {
            var result = repository.CheckCourse(course);
            return Ok(result);
        }

        [HttpPost("applyforcourse")]
        public IActionResult ApplyCourse([FromBody] Course course)
        {
            var result = repository.ApplyCourse(course);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        // POST: api/Student
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Student/5
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
