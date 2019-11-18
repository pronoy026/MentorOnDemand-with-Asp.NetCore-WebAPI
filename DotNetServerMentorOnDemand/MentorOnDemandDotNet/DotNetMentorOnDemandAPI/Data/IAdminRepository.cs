using DotNetMentorOnDemandAPI.DTOs;
using DotNetMentorOnDemandAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMentorOnDemandAPI.Data
{
    public interface IAdminRepository
    {
        IEnumerable<UserDto> GetActiveUsersByRole(string roleId);
        IEnumerable<UserDto> GetBlockedUsersByRole(string roleId);
        IEnumerable<CourseDto> GetAllCourses();

        bool RegisterTechnology(Technology technology);
        bool BlockUnblockUser(string userId);
    }
}
