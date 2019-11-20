using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMentorOnDemandAPI.DTOs
{
    public class NotificationDto
    {
        public int NotiId { get; set; }
        public int Fee { get; set; }
        public string CourseName { get; set; }
        public UserDto Mentor { get; set; }
        public UserDto Student { get; set; }
        public string Type { get; set; }
        public int CompletionStatus { get; set; }
    }
}
