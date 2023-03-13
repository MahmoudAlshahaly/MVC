using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Models
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public int degree { get; set; }
        public int mindegree { get; set; }
        [ForeignKey("Department")]
        public int Department_id { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<CourseResult> CourseResults { get; set; }
    }
}
