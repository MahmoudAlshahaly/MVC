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
        private readonly IGenericRepo<Instructor> instructorRepo;
        private readonly IGenericRepo<Department> departmentRepo;
        private readonly IGenericRepo<Course> courseRepo;
        private readonly IHostingEnvironment hostingEnvironment;

        public InstructorController(
            IGenericRepo<Instructor> _instructorRepo,
            IGenericRepo<Department> _departmentRepo,
            IGenericRepo<Course> _courseRepo,
            IHostingEnvironment hostingEnvironment)
        {
            instructorRepo = _instructorRepo;
            departmentRepo = _departmentRepo;
            courseRepo = _courseRepo;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult GetAll()
        {
          var All= instructorRepo.GetAll().Include(x => x.Department).Select(x =>
          new InstructorViewModel
          {
              id = x.id,
              name = x.name,
              salary = x.salary,
              address = x.address,
              image = x.image,
              
              Department = new Department { id = x.Department.id, name = x.Department.name }
          }).ToList();
            return View(All);
        }
        public IActionResult Details(int id)
        {
        
            return View(model(id));
        }
        private InstructorViewModel model(int id)
        {
            var instru = instructorRepo.GetByID(id);
            var model = new InstructorViewModel
            {
                id = instru.id,
                name = instru.name,
                salary = instru.salary,
                address = instru.address,
                image = instru.image,
                Department = departmentRepo.GetByID(instru.Department_id)
            };
            return model;
        }
        public IActionResult Delete(int id)
        {
            return View(model(id));
        }
        [HttpPost]
        public IActionResult Delete(int id, Instructor instructor)
        {
            instructorRepo.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }
        string path;
        public IActionResult Edit(int id)
        {
            var department = instructorRepo.GetByID(id);
            path = department.image;
            var model = new InstructorViewModel
            {
                id = department.id,
                name = department.name,
                salary = department.salary,
                address = department.address,
                image = department.image,
                Department_id = department.Department_id,
                Departments = departmentRepo.GetAll().ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(InstructorViewModel model)
        {
            string filename = string.Empty;
            if (model.file != null)
            {
                string uploads = Path.Combine(hostingEnvironment.WebRootPath, "image");
                filename = model.file.FileName;
                string fullpath = Path.Combine(uploads, filename);

                string oldfilename = instructorRepo.GetAll().Where(a=>a.id==model.id).AsNoTracking().SingleOrDefault().image;
                string fulloldpath = Path.Combine(uploads, oldfilename);
                if (fullpath != oldfilename)
                {
                    System.IO.File.Delete(fulloldpath);
                    model.file.CopyTo(new FileStream(fullpath, FileMode.Create));
                }
            }
            Instructor instru = new Instructor();
            instru.id = model.id;
            instru.name = model.name;
            instru.salary = model.salary;
            if (model.file != null)
            {
                instru.image = filename;
            }
            instru.address = model.address;
            instru.Department = departmentRepo.GetByID(model.Department_id);

            instructorRepo.Update(instru);
            return RedirectToAction(nameof(GetAll));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new InstructorViewModel
            {
                Departments = departmentRepo.GetAll().ToList()
            };
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
            }
            Instructor instru = new Instructor();
            instru.id = model.id;
            instru.name = model.name;
            instru.salary = model.salary;
            instru.image = filename;
            instru.address = model.address;
            instru.Department = departmentRepo.GetByID(model.Department_id);
            instructorRepo.Insert(instru);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
