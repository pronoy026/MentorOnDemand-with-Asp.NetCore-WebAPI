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
        IEnumerable<Payment> GetAllPayments();
        bool RegisterTechnology(Technology technology);
        bool BlockUnblockUser(string userId);

        IEnumerable<CourseDto> GetSearchData(string searchString);
        IEnumerable<Technology> GetTechnologies();
        bool UpdateTechnology(Technology technology);
        IEnumerable<IndividualCourseDto> GetAdminDashIndividualCourses();


    }
}
