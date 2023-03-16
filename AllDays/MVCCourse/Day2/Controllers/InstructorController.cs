using Day2.interfaces;
using Day2.Models;
using Day2.repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IGenericRepo<Department> departmentRepo;
        private readonly IGenericRepo<Course> courseRepo;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly BL.BLInstructor bLInstructor;

        public InstructorController(
            IGenericRepo<Department> _departmentRepo,
            IGenericRepo<Course> _courseRepo,
            IWebHostEnvironment _webHostEnvironment,
            BL.BLInstructor _bLInstructor
            )
        {
            departmentRepo = _departmentRepo;
            courseRepo = _courseRepo;
            webHostEnvironment = _webHostEnvironment;
            bLInstructor = _bLInstructor;
        }
        public IActionResult GetAll()
        {
            var all2 = bLInstructor.GetAll();
            return View(all2);
        }
        public IActionResult Details(int id)
        {
            var s = bLInstructor.GetByID(id);
        
            return View(s);
        }
        public IActionResult Delete(int id)
        {
            var s = bLInstructor.GetByID(id);

            return View(s);
        }
        [HttpPost]
        public IActionResult Delete(int id,Instructor instructor)
        {
            bLInstructor.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }
        public IActionResult Edit(int id)
        {
          //ViewData["DropDown"] = departmentRepo.GetAll().Select(a => new {id = a.id , name= a.name}).ToList();
            ViewData["DropDown"] = departmentRepo.GetAll().ToList();
            var m2 = bLInstructor.GetByID(id);
            return View(m2);
        }
        [HttpPost]
        public IActionResult Edit(InstructorViewModel model)
        {
            var instru = bLInstructor.GetByIDNoTracking(model.id);

            string filename = string.Empty;
            if (model.file != null)
            {
                string uploads = Path.Combine(hostingEnvironment.WebRootPath, "image");
                filename = model.file.FileName;
                string fullpath = Path.Combine(uploads, filename);

                string oldfilename = instru.image;
                string fulloldpath = Path.Combine(uploads, oldfilename);
          
                if (fullpath != oldfilename)
                {
                    System.IO.File.Delete(fulloldpath);
                    model.file.CopyTo(new FileStream(fullpath, FileMode.Create));
                }
                instru.image = filename; 
            }

            bLInstructor.Update(instru);
            return RedirectToAction(nameof(GetAll));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new InstructorViewModel
            {
                Departments = departmentRepo.GetAll().ToList()
            };

            // ViewData["DropDown"] = departmentRepo.GetAll().Select(a => new {id = a.id , name= a.name}).ToList();
            //ViewData["DropDown"] = departmentRepo.GetAll().ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(InstructorViewModel model)
        {
            string filename = string.Empty;
            if(model.file !=null)
            {
               
                string uploads = Path.Combine(hostingEnvironment.WebRootPath, "image");
                filename = model.file.FileName;
                string fullpath = Path.Combine(uploads, filename);
                model.file.CopyTo(new FileStream(fullpath,FileMode.Create));
                model.image = filename;

            }

            bLInstructor.Insert(model);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
