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
    }
}
