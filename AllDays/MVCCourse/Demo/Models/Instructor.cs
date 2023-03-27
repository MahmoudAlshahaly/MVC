using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Models
{
    public class Instructor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public decimal salary { get; set; }
        public string address { get; set; }
        [ForeignKey("Department")]
        public int Department_id { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
