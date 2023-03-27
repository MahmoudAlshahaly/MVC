using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Models
{
    public class CourseResult
    {
        public int id { get; set; }
        public int degree { get; set; }

        [ForeignKey("Course")]
        public int Course_id { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("Trainee")]
        public int Trainee_id { get; set; }
        public virtual Trainee Trainee { get; set; }

    }
}
