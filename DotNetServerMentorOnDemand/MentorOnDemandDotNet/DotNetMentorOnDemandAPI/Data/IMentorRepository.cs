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

        bool CreateSkill(MentorSkill mentorSkill);
    }
}
