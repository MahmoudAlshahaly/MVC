using Day2.interfaces;
using Day2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Controllers
{
    public class CourseController : Controller
    {
        private readonly BL.BLCourse bLCourse;
        private readonly IGenericRepo<Department> departmentRepo;

        public CourseController(BL.BLCourse _bLCourse, IGenericRepo<Department> _departmentRepo)
        {
            bLCourse = _bLCourse;
            departmentRepo = _departmentRepo;
        }
        public IActionResult Index()
        {
            var all2 = bLCourse.GetAll();
            return View(all2);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CourseViewModel
            {
                Departments = departmentRepo.GetAll().ToList()
            };

            // ViewData["DropDown"] = departmentRepo.GetAll().Select(a => new {id = a.id , name= a.name}).ToList();
            //ViewData["DropDown"] = departmentRepo.GetAll().ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                bLCourse.Insert(model);
                return RedirectToAction(nameof(Index));
            }
            return View("create");
        }

        public IActionResult Delete(int id)
        {
            var s = bLCourse.GetByID(id);

            return View(s);
        }
        [HttpPost]
        public IActionResult Delete(int id, Course course)
        {
            bLCourse.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
