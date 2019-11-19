using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetMentorOnDemandAPI.DTOs;
using DotNetMentorOnDemandAPI.Models;

namespace DotNetMentorOnDemandAPI.Data
{
    public class StudentRepository : IStudentRepository
    {
        AppDBContext context;
        public StudentRepository(AppDBContext context)
        {
            this.context = context;
        }

        public bool ApplyCourse(Course course)
        {
            try
            {
                context.Courses.Add(course);
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CheckCourse(Course course)
        {
            try
            {
                course = context.Courses.Where(c => c.MentorSkillId == course.MentorSkillId && c.StudentEmail == course.StudentEmail).FirstOrDefault();
                if(course == null)
                {
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<IndividualCourseDto> GetAppliedCourses(Course course)
        {
            var courses = (from s in context.MentorSkills
                           join t in context.Technologies on s.TechId equals t.Id
                           join c in context.Courses on s.Id equals c.MentorSkillId
                           where(c.StudentEmail == course.StudentEmail && c.IsRequested == true)
                           select new IndividualCourseDto
                           {
                               Name = t.Name,
                               Description = t.Description,
                               Fee = t.Fee,
                               ImageUrl = t.ImageUrl,
                               Duration = t.Duration,
                               MentorSkillId = s.Id,
                               Mentor = (
                                       from u in context.CustomUsers
                                       where (s.MentorEmail == u.Email)
                                       select new UserDto
                                       {
                                           Id = u.Id,
                                           Email = u.Email,
                                           Name = u.Name,
                                           Role = "Mentor",
                                           IsBlocked = u.IsBlocked,
                                           PhoneNumber = u.PhoneNumber
                                       }).FirstOrDefault(),
                               StartDate = s.StartDate.ToLongDateString(),
                               EndDate = s.EndDate.ToLongDateString()
                           }
                );
            return courses;
        }

        public IEnumerable<IndividualCourseDto> GetRejectedCourses(Course course)
        {
            var courses = (from s in context.MentorSkills
                           join t in context.Technologies on s.TechId equals t.Id
                           join c in context.Courses on s.Id equals c.MentorSkillId
                           where (c.StudentEmail == course.StudentEmail && c.IsRejected == true)
                           select new IndividualCourseDto
                           {
                               Name = t.Name,
                               Description = t.Description,
                               Fee = t.Fee,
                               ImageUrl = t.ImageUrl,
                               Duration = t.Duration,
                               MentorSkillId = s.Id,
                               Mentor = (
                                       from u in context.CustomUsers
                                       where (s.MentorEmail == u.Email)
                                       select new UserDto
                                       {
                                           Id = u.Id,
                                           Email = u.Email,
                                           Name = u.Name
                                       }).FirstOrDefault(),
                               StartDate = s.StartDate.ToLongDateString(),
                               EndDate = s.EndDate.ToLongDateString(),
                               CompletionStatus = c.CompletionStatus,
                               Rating = c.Rating
                           }
                );
            return courses;
        }
    }
}
