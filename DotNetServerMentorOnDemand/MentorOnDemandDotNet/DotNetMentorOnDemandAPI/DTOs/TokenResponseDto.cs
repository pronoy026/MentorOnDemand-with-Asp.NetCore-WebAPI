using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMentorOnDemandAPI.DTOs
{
    public class TokenResponseDto
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
    }
}
