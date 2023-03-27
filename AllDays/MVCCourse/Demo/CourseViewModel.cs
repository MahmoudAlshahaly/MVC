using Day2.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Day2
{
    public class CourseViewModel
    {
        public int id { get; set; }
        [Required]
        [MaxLength(20,ErrorMessage ="max length 20")]
        [MinLength(2, ErrorMessage = "min length 2")]
        public string name { get; set; }
        [Required]
        [Range(50,100)]
        public int degree { get; set; }
        [Required]
        [ValidateMinLessThanDegree]

        public int mindegree { get; set; }
        public int Department_id { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<Department> Departments{ get; set; }
    }
}
