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
