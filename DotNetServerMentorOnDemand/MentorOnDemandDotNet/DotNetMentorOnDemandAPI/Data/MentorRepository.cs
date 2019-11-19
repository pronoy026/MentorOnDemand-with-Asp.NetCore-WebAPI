﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetMentorOnDemandAPI.DTOs;
using DotNetMentorOnDemandAPI.Models;

namespace DotNetMentorOnDemandAPI.Data
{
    public class MentorRepository : IMentorRepository
    {
        AppDBContext context;
        public MentorRepository(AppDBContext context)
        {
            this.context = context;
        }

        

        public bool CreateSkill(MentorSkill mentorSkill)
        {
            try
            {
                context.MentorSkills.Add(mentorSkill);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<IndividualCourseDto> GetAppliedCourses(string MentorEmail)
        {
            try
            {
                var courses = (from s in context.MentorSkills
                               join t in context.Technologies on s.TechId equals t.Id
                               join c in context.Courses on s.Id equals c.MentorSkillId
                               where (s.MentorEmail == MentorEmail && c.IsRequested == true)
                               select new IndividualCourseDto
                               {
                                   Name = t.Name,
                                   Description = t.Description,
                                   Fee = t.Fee,
                                   ImageUrl = t.ImageUrl,
                                   Duration = t.Duration,
                                   MentorSkillId = s.Id,
                                   Student = (
                                           from u in context.CustomUsers
                                           where (c.StudentEmail == u.Email)
                                           select new UserDto
                                           {
                                               Id = u.Id,
                                               Email = u.Email,
                                               Name = u.Name
                                           }).FirstOrDefault(),
                                   StartDate = s.StartDate.ToLongDateString(),
                                   EndDate = s.EndDate.ToLongDateString()
                               }
                );
                return courses;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<IndividualCourseDto> GetRegisteredCourses(string MentorEmail)
        {
            try
            {
                var courses = (from s in context.MentorSkills
                               join t in context.Technologies on s.TechId equals t.Id
                               join c in context.Courses on s.Id equals c.MentorSkillId
                               where (s.MentorEmail == MentorEmail && c.IsRegistered == true)
                               select new IndividualCourseDto
                               {
                                   Name = t.Name,
                                   Description = t.Description,
                                   Fee = t.Fee,
                                   ImageUrl = t.ImageUrl,
                                   Duration = t.Duration,
                                   MentorSkillId = s.Id,
                                   Student = (
                                           from u in context.CustomUsers
                                           where (c.StudentEmail == u.Email)
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
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<IndividualCourseDto> GetCompletedCourses(string MentorEmail)
        {
            try
            {
                var courses = (from s in context.MentorSkills
                               join t in context.Technologies on s.TechId equals t.Id
                               join c in context.Courses on s.Id equals c.MentorSkillId
                               where (s.MentorEmail == MentorEmail && c.IsCompleted == true)
                               select new IndividualCourseDto
                               {
                                   Name = t.Name,
                                   Description = t.Description,
                                   Fee = t.Fee,
                                   ImageUrl = t.ImageUrl,
                                   Duration = t.Duration,
                                   MentorSkillId = s.Id,
                                   Student = (
                                           from u in context.CustomUsers
                                           where (c.StudentEmail == u.Email)
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
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<IndividualCourseDto> GetRejectedCourses(string MentorEmail)
        {
            try
            {
                var courses = (from s in context.MentorSkills
                               join t in context.Technologies on s.TechId equals t.Id
                               join c in context.Courses on s.Id equals c.MentorSkillId
                               where (s.MentorEmail == MentorEmail && c.IsRejected == true)
                               select new IndividualCourseDto
                               {
                                   Name = t.Name,
                                   Description = t.Description,
                                   Fee = t.Fee,
                                   ImageUrl = t.ImageUrl,
                                   Duration = t.Duration,
                                   MentorSkillId = s.Id,
                                   Student = (
                                           from u in context.CustomUsers
                                           where (c.StudentEmail == u.Email)
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
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Technology> GetTechnologies()
        {
            try
            {
                return context.Technologies.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool MentorSkillExists(int techId, string mentorEmail)
        {
            try
            {
                var skill = context.MentorSkills.Where(s => s.TechId == techId && s.MentorEmail == mentorEmail).FirstOrDefault();
                if(skill!=null)
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

        public bool AcceptCourse(Course course)
        {
            var findcourse = context.Courses.Where(c => c.MentorSkillId == course.MentorSkillId && c.StudentEmail == course.StudentEmail).FirstOrDefault();
            findcourse.IsCompleted = false;
            findcourse.IsRegistered = true;
            findcourse.IsRejected = false;
            findcourse.IsRequested = false;
            var result = context.SaveChanges();
            if (result>0)
            {
                return true;
            }
            return false;
        }

        public bool RejectCourse(Course course)
        {
            var findcourse = context.Courses.Where(c => c.MentorSkillId == course.MentorSkillId && c.StudentEmail == course.StudentEmail).FirstOrDefault();
            findcourse.IsCompleted = false;
            findcourse.IsRegistered = false;
            findcourse.IsRejected = true;
            findcourse.IsRequested = false;
            var result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
