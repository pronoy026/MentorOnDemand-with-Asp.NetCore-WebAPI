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
                var noti = new Notification
                {
                    StudentEmail = course.StudentEmail,
                    MentorSkillId = course.MentorSkillId,
                    Type = "request",
                    IsStudent = false,
                    IsMentor = true,
                    CompletionStatus = 0
                };
                context.Notifications.Add(noti);
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

        public bool CourseCompletionStatusUpdate(Course course)
        {
            try
            {
                var findCourse = context.Courses.Where(c => c.StudentEmail == course.StudentEmail && c.MentorSkillId == course.MentorSkillId).FirstOrDefault();
                if (findCourse.CompletionStatus >= course.CompletionStatus)
                {
                    return false;
                }
                else
                {
                    findCourse.CompletionStatus = course.CompletionStatus;
                    var noti = new Notification
                    {
                        StudentEmail = course.StudentEmail,
                        MentorSkillId = course.MentorSkillId,
                        Type = "payment",
                        IsStudent = false,
                        IsMentor = true,
                        CompletionStatus = course.CompletionStatus
                    };
                    context.Notifications.Add(noti);
                }
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CourseCompletionUpdate(Course course)
        {
            try
            {
                var findCourse = context.Courses.Where(c => c.StudentEmail == course.StudentEmail && c.MentorSkillId == course.MentorSkillId).FirstOrDefault();
                findCourse.CompletionStatus = course.CompletionStatus;
                findCourse.IsCompleted = true;
                findCourse.IsRegistered = false;
                findCourse.IsRejected = false;
                findCourse.IsRequested = false;
                findCourse.IsConfirmed = false;
                context.SaveChanges();
                var noti = new Notification
                {
                    StudentEmail = course.StudentEmail,
                    MentorSkillId = course.MentorSkillId,
                    Type = "complete",
                    IsStudent = true,
                    IsMentor = true,
                    CompletionStatus = course.CompletionStatus
                };
                context.Notifications.Add(noti);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<IndividualCourseDto> GetAppliedCourses(string StudentEmail)
        {
            var courses = (from s in context.MentorSkills
                           join t in context.Technologies on s.TechId equals t.Id
                           join c in context.Courses on s.Id equals c.MentorSkillId
                           where(c.StudentEmail == StudentEmail && c.IsRequested == true)
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

        public IEnumerable<IndividualCourseDto> GetCompletedCourses(string StudentEmail)
        {
            var courses = (from s in context.MentorSkills
                           join t in context.Technologies on s.TechId equals t.Id
                           join c in context.Courses on s.Id equals c.MentorSkillId
                           where (c.StudentEmail == StudentEmail && c.IsCompleted == true)
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

        public IEnumerable<IndividualCourseDto> GetConfirmedCourses(string StudentEmail)
        {
            var courses = (from s in context.MentorSkills
                           join t in context.Technologies on s.TechId equals t.Id
                           join c in context.Courses on s.Id equals c.MentorSkillId
                           where (c.StudentEmail == StudentEmail && c.IsConfirmed == true)
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

        public IEnumerable<IndividualCourseDto> GetRegisteredCourses(string StudentEmail)
        {
            var courses = (from s in context.MentorSkills
                           join t in context.Technologies on s.TechId equals t.Id
                           join c in context.Courses on s.Id equals c.MentorSkillId
                           where (c.StudentEmail == StudentEmail && c.IsRegistered == true)
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

        public IEnumerable<IndividualCourseDto> GetRejectedCourses(string StudentEmail)
        {
            var courses = (from s in context.MentorSkills
                           join t in context.Technologies on s.TechId equals t.Id
                           join c in context.Courses on s.Id equals c.MentorSkillId
                           where (c.StudentEmail == StudentEmail && c.IsRejected == true)
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

        public bool RegisterCourse(Course course)
        {
            var findcourse = context.Courses.Where(c => c.MentorSkillId == course.MentorSkillId && c.StudentEmail == course.StudentEmail).FirstOrDefault();
            findcourse.IsCompleted = false;
            findcourse.IsRegistered = true;
            findcourse.IsRejected = false;
            findcourse.IsRequested = false;
            findcourse.IsConfirmed = false;
            var result = context.SaveChanges();

            var noti = new Notification
            {
                StudentEmail = course.StudentEmail,
                MentorSkillId = course.MentorSkillId,
                Type = "register",
                IsStudent = false,
                IsMentor = true,
                CompletionStatus = 0
            };
            context.Notifications.Add(noti);
            context.SaveChanges();

            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
