using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMentorOnDemandAPI.Models
{
    public class Course
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        [Required]
        public int MentorSkillId { get; set; }
        public bool IsRequested { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsCompleted { get; set; }
    }
}
