using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.Models;

namespace SchoolSystem.Core.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Exam> Exams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudentRelation>()
          .HasKey(csr => new { csr.CourseId, csr.StudentId });

            modelBuilder.Entity<CourseTeacherRelation>()
                .HasKey(ctr => new { ctr.CourseId, ctr.TeacherId });

           
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CourseTeacherRelation>()
        .HasKey(ctr => new { ctr.CourseId, ctr.TeacherId });

            modelBuilder.Entity<CourseTeacherRelation>()
                .HasOne(ctr => ctr.Course)
                .WithMany(c => c.CourseTeacherRelations)
                .HasForeignKey(ctr => ctr.CourseId)
                .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE NO ACTION

            modelBuilder.Entity<CourseTeacherRelation>()
                .HasOne(ctr => ctr.Teacher)
                .WithMany(t => t.CourseTeacherRelations)
                .HasForeignKey(ctr => ctr.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
