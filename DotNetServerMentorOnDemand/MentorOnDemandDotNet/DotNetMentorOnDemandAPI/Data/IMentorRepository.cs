using DotNetMentorOnDemandAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMentorOnDemandAPI.Data
{
    public interface IMentorRepository
    {
        public IEnumerable<Technology> GetTechnologies();

        bool MentorSkillExists(int techId, string mentorEmail);
        bool CreateSkill(MentorSkill mentorSkill);
    }
}
