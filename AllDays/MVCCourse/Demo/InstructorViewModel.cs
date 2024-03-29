﻿using Day2.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Day2
{
    public class InstructorViewModel
    {
        public int id { get; set; }
        [Required]

        public string name { get; set; }
        [Required]

        public string image { get; set; }
        [Required]
        [MaxLength(50)]
        public decimal salary { get; set; }
        public string address { get; set; }
        public int Department_id { get; set; }
        public Department Department { get; set; }
        public List<Department> Departments { get; set; }
        public IFormFile file { get; set; }
    }
}
