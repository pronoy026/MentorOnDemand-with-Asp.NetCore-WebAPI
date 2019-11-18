using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetMentorOnDemandAPI.Models;

namespace DotNetMentorOnDemandAPI.Data
{
    public class StudentRepository : IStudentRepository
    {
        AppDBContext context;
        public StudentRepository(AppDBContext context)
        {
            this.context = context;
        }

        public bool ApplyCourse(Course course)
        {
            try
            {
                context.Courses.Add(course);
                context.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CheckCourse(Course course)
        {
            try
            {
                course = context.Courses.Where(c => c.MentorSkillId == course.MentorSkillId && c.StudentEmail == course.StudentEmail).FirstOrDefault();
                if(course == null)
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
