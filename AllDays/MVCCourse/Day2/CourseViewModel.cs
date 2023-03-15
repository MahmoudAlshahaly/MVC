using Day2.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Day2
{
    public class CourseViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int degree { get; set; }
        public int mindegree { get; set; }
        public int Department_id { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<Department> Departments{ get; set; }
    }
}
