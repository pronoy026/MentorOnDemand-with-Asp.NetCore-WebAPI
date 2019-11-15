using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetMentorOnDemandAPI.Data;
using DotNetMentorOnDemandAPI.DTOs;
using DotNetMentorOnDemandAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMentorOnDemandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {


        IAdminRepository repository;
        public AdminController(IAdminRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/Admin
        [HttpGet("getactiveusers/{id}")]
        public IEnumerable<UserDto> GetActiveUsersByRole(string id)
        {
            var users = repository.GetActiveUsersByRole(id);
            return users;
        }

        [HttpGet("blockunblockuser/{id}")]
        public IActionResult BlockUnblockUser(string id)
        {
            var result = repository.BlockUnblockUser(id);
            return Ok(result);
        }

        [HttpGet("getblockedusers/{id}")]
        public IEnumerable<UserDto> GetBlockedUsersByRole(string id)
        {
            var users = repository.GetBlockedUsersByRole(id);
            return users;
        }

        // POST: api/Admin
        [HttpPost("registertech")]
        public bool Post([FromBody] Technology technology)
        {
            return repository.RegisterTechnology(technology);
        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Admin/5
        [HttpDelete("coursedelete/{id}")]
        public void Delete(int id)
        {

        }
    }
}
