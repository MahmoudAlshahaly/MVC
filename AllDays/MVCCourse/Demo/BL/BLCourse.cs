using AutoMapper;
using Day2.interfaces;
using Day2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.BL
{
    public class BLCourse
    {
        private readonly IGenericRepo<Course> courseRepo;
        private readonly IMapper mapper;

        public BLCourse(IGenericRepo<Course> _courseRepo, IMapper _mapper)
        {
            courseRepo = _courseRepo;
            mapper = _mapper;
        }
        public List<CourseViewModel> GetAll()
        {
            var courseList = courseRepo.GetAll().Include(dept=>dept.Department).ToList();
            var courseVMList = mapper.Map< List<Course>,List<CourseViewModel>>(courseList);
            return courseVMList;
        }
        public CourseViewModel GetByID(int id)
        {
            var course = courseRepo.GetAll().Include(dept => dept.Department).FirstOrDefault(a=>a.id==id);
            var courseVM = mapper.Map<Course, CourseViewModel>(course);
            return courseVM;
        }
        public CourseViewModel GetByIDNoTracking(int id)
        {
            var course = courseRepo.GetAll().Where(a => a.id == id).AsNoTracking().ToList().FirstOrDefault();
            var courseVM = mapper.Map<Course, CourseViewModel>(course);
            return courseVM;
        }
        public  void Delete(int id)
        {
            courseRepo.Delete(id);
        }
        public CourseViewModel Update(CourseViewModel entity)
        {
            var course = mapper.Map<CourseViewModel, Course>(entity);
            courseRepo.Update(course);
            return entity;
        }
        public CourseViewModel Insert(CourseViewModel entity)
        {
            var course = mapper.Map<CourseViewModel, Course>(entity);
            courseRepo.Insert(course);
            return entity;
        }
    }
}
