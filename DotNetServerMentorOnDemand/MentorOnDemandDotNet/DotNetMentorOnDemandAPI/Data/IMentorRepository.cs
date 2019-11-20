using DotNetMentorOnDemandAPI.DTOs;
using DotNetMentorOnDemandAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMentorOnDemandAPI.Data
{
    public interface IMentorRepository
    {
        public IEnumerable<Technology> GetTechnologies();
        public IEnumerable<IndividualCourseDto> GetAppliedCourses(string MentorEmail);
        public IEnumerable<IndividualCourseDto> GetRegisteredCourses(string MentorEmail);
        public IEnumerable<IndividualCourseDto> GetCompletedCourses(string MentorEmail);
        public IEnumerable<IndividualCourseDto> GetRejectedCourses(string MentorEmail);
        public IEnumerable<IndividualCourseDto> GetConfirmedCourses(string MentorEmail);

        public IEnumerable<NotificationDto> GetNotifications(string email);

        public bool AcceptCourse(Course course);
        public bool RejectCourse(Course course);
        bool MentorSkillExists(int techId, string mentorEmail);
        bool CreateSkill(MentorSkill mentorSkill);
    }
}
