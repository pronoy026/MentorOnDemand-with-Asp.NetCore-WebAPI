using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMentorOnDemandAPI.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public int Rating { get; set; }
        public int Experience { get; set; }
    }
}
