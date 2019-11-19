using DotNetMentorOnDemandAPI.DTOs;
using DotNetMentorOnDemandAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMentorOnDemandAPI.Data
{
    public interface IStudentRepository
    {
        public IEnumerable<IndividualCourseDto> GetAppliedCourses(Course course);
        public IEnumerable<IndividualCourseDto> GetRejectedCourses(Course course);
        public bool CheckCourse(Course course);

        public bool ApplyCourse(Course course);
    }
}
