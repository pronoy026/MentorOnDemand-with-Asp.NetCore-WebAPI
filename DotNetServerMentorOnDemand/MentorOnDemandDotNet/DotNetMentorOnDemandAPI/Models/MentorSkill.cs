using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMentorOnDemandAPI.Models
{
    public class MentorSkill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string mentorEmail { get; set; }
        public DateTime Start { get; set; }
        public int MyProperty { get; set; }
    }
}
