using AutoMapper;
using Day2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.Mapping
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
           /// CreateMap<Instructor, InstructorViewModel>().ReverseMap();
            CreateMap<Instructor, InstructorViewModel>().IncludeMembers(ins => ins.Department);
            CreateMap<InstructorViewModel, Instructor>();
            CreateMap<Department, InstructorViewModel>(MemberList.None);

            CreateMap<Course, CourseViewModel>().IncludeMembers(ins => ins.Department);
            CreateMap<CourseViewModel, Course>();
            CreateMap<Department, CourseViewModel>(MemberList.None);
        }
    }
}
