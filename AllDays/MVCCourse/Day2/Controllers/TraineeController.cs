using Day2.interfaces;
using Day2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Controllers
{
    public class TraineeController : Controller
    {
        private readonly IGenericRepo<Trainee> traineeRepo;
        private readonly IGenericRepo<Course> courseRepo;
        private readonly IGenericRepo<CourseResult> courseResultRepo;

        public TraineeController(IGenericRepo<Trainee> _traineeRepo , IGenericRepo<Course> _courseRepo, IGenericRepo<CourseResult> _courseResultRepo)
        {
            traineeRepo = _traineeRepo;
            courseRepo = _courseRepo;
            courseResultRepo = _courseResultRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowResult(int student_id,int course_id)
        {
           var student= traineeRepo.GetByID(student_id);
           var course = courseRepo.GetByID(course_id);
           var courseresult = courseResultRepo.GetAll().Where(a=>a.Course_id==course_id && a.Trainee_id==student_id).FirstOrDefault();
          
            var model = new CourseResultViewModel 
            {
                studentname=student.name,
                coursename=course.name,
                degree=courseresult.degree,
                color="red"
            };
            if (courseresult.degree >= course.mindegree)
            {
                model.color = "green";
            }
            return View(model);
        
        }
        public IActionResult ShowCourseResult()
        { 
          var courseresult = courseResultRepo.GetAll().Include(s=>s.Trainee).Include(c=>c.Course).Select(x =>
            new CourseResultViewModel
          {
                course_id=x.Course_id,
              studentname = x.Trainee.name,
              coursename = x.Course.name,
              degree = x.degree,
          }).ToList();

            for (int i = 0; i < courseresult.Count(); i++)
            {
                var course = courseRepo.GetByID(courseresult[i].course_id);
                courseresult[i].mindegree = course.mindegree;
                if (courseresult[i].degree >= course.mindegree)
                {
                    courseresult[i].color = "green";

                }
                else
                {
                    courseresult[i].color = "red";
                }
            }
           
            return View(courseresult);

        }
    }
}
