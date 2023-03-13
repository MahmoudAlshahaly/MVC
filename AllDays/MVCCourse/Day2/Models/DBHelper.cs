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
        public DbSet<Course> courses { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Trainee>  trainees { get; set; }
        public DbSet<CourseResult> courseResults { get; set; }
    }
}
