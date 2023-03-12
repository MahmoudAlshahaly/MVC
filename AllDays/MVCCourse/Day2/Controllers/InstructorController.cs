using Day2.interfaces;
using Day2.Models;
using Day2.repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepo instructorRepo;

        public InstructorController(IInstructorRepo _instructorRepo)
        {
            instructorRepo = _instructorRepo;
        } 
         
        public IActionResult GetAllInstructor()
        {

            return View(instructorRepo.GetAll());
        }
        public IActionResult GetByIDInstructor(int id)
        {

            return View(instructorRepo.GetByID(id));
        }
    }
}
