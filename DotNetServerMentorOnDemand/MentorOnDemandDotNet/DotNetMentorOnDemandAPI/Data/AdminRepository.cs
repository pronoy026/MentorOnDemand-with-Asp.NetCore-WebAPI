using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetMentorOnDemandAPI.DTOs;
using DotNetMentorOnDemandAPI.Models;

namespace DotNetMentorOnDemandAPI.Data
{
    public class AdminRepository : IAdminRepository
    {
        AppDBContext context;
        public AdminRepository(AppDBContext context)
        {
            this.context = context;
        }

        public bool BlockUnblockUser(string userId)
        {
            try
            {
                var appUser = context.CustomUsers.Where(u => u.Id == userId).FirstOrDefault();
                appUser.IsBlocked = !appUser.IsBlocked;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<UserDto> GetActiveUsersByRole(string roleId)
        {
            var users = (from u in context.CustomUsers
                         join r in context.UserRoles on u.Id equals r.UserId
                         where (r.RoleId == roleId && u.IsBlocked ==  false)
                         select new UserDto
                         {
                             Id = u.Id,
                             Email = u.Email,
                             Name = u.Name,
                             Role = r.RoleId,
                             IsBlocked = u.IsBlocked,
                             PhoneNumber = u.PhoneNumber
                         });
            return users.ToList();
        }

        public IEnumerable<CourseDto> GetAllCourses()
        {
            var courses = (from s in context.MentorSkills
                           join t in context.Technologies on s.TechId equals t.Id
                           select new CourseDto
                           {
                               Name= t.Name,
                               Description= t.Description,
                               Fee = t.Fee,
                               ImageUrl = t.ImageUrl,
                               Duration = t.Duration,
                               MentorSkillId = s.Id,
                               Mentor= (
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

        public IEnumerable<UserDto> GetBlockedUsersByRole(string roleId)
        {
            var users = (from u in context.CustomUsers
                         join r in context.UserRoles on u.Id equals r.UserId
                         where (r.RoleId == roleId && u.IsBlocked == true)
                         select new UserDto
                         {
                             Id = u.Id,
                             Email = u.Email,
                             Name = u.Name,
                             Role = r.RoleId,
                             IsBlocked = u.IsBlocked,
                             PhoneNumber = u.PhoneNumber
                         });
            return users.ToList();
        }

        public bool RegisterTechnology(Technology technology)
        {
            try
            {
                context.Technologies.Add(technology);
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
