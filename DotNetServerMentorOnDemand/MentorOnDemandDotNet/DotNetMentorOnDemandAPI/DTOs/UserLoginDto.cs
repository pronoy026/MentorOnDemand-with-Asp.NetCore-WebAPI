using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMentorOnDemandAPI.DTOs
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]

        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        public int Role { get; set; }
    }
}
