using Day2.Configration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Models
{
    public class DBHelper:DbContext
    {
        public DBHelper(DbContextOptions ops):base(ops)
        {
                
        }

        public DBHelper()
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}
        //fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Course>()
            //            .HasOne(c => c.Department)
            //            .WithMany(c => c.Courses)
            //            .IsRequired()
            //            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.ApplyConfiguration(new InstructorConfigration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Course> courses { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Trainee>  trainees { get; set; }
        public DbSet<CourseResult> courseResults { get; set; }
    }
}
