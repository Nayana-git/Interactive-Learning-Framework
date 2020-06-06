using System;
using System.Collections.Generic;
using System.Text;
using InteractiveLearningFramework.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InteractiveLearningFramework.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, UserRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var table = entityType.Relational().TableName;
                if (table.StartsWith("AspNet"))
                {
                    entityType.Relational().TableName = table.Substring(6);
                }
            };

            modelBuilder.Entity<CourseInstructor>().HasKey(ci => new { ci.CourseId, ci.UserId });

            modelBuilder.Entity<CourseInstructor>()
                .HasOne(bc => bc.Instructor)
                .WithMany(b => b.Instructors)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<CourseInstructor>()
                .HasOne(bc => bc.Course)
                .WithMany(c => c.Instructors)
                .HasForeignKey(bc => bc.CourseId);

            modelBuilder.Entity<CourseEnrollment>().HasKey(ci => new { ci.CourseId, ci.UserId });

            modelBuilder.Entity<CourseEnrollment>()
                .HasOne(abc => abc.User)
                .WithMany(b => b.CourseEnrollments)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<CourseEnrollment>()
                .HasOne(bc => bc.Course)
                .WithMany(c => c.CourseEnrollments)
                .HasForeignKey(bc => bc.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany<Module>(g => g.Modules)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
               .HasMany<Announcement>(g => g.Announcement)
               .WithOne(s => s.Course)
               .HasForeignKey(s => s.CourseId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Module>()
              .HasMany<SubModule>(g => g.SubModules)
              .WithOne(s => s.Module)
              .HasForeignKey(s => s.ModuleId)
              .OnDelete(DeleteBehavior.Cascade);


        }
        public DbSet<InteractiveLearningFramework.Models.Course> Course { get; set; }
        public DbSet<InteractiveLearningFramework.Models.CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<InteractiveLearningFramework.Models.SubModule> SubModules { get; set; }
     
        public DbSet<InteractiveLearningFramework.Models.Module> Modules { get; set; }
    }
}
