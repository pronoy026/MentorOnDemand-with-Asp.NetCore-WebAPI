using DotNetMentorOnDemandAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMentorOnDemandAPI.Data
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext([NotNullAttribute] DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>(role => role.HasData(new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "Admin"
            },
            new IdentityRole
            {
                Id = "2",
                Name = "Mentor",
                NormalizedName = "Mentor"

            },
            new IdentityRole
            {
                Id = "3",
                Name = "Student",
                NormalizedName = "Student"
            }
            ));

            base.OnModelCreating(builder);
        }

        public DbSet<UserModel> CustomUsers { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<MentorSkill> MentorSkills { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
