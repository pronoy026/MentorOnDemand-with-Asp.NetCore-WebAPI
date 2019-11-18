using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetMentorOnDemandAPI.Models;

namespace DotNetMentorOnDemandAPI.Data
{
    public class MentorRepository : IMentorRepository
    {
        AppDBContext context;
        public MentorRepository(AppDBContext context)
        {
            this.context = context;
        }

        public bool CreateSkill(MentorSkill mentorSkill)
        {
            try
            {
                context.MentorSkills.Add(mentorSkill);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Technology> GetTechnologies()
        {
            try
            {
                return context.Technologies.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool MentorSkillExists(int techId, string mentorEmail)
        {
            try
            {
                var skill = context.MentorSkills.Where(s => s.TechId == techId && s.MentorEmail == mentorEmail).FirstOrDefault();
                if(skill!=null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
