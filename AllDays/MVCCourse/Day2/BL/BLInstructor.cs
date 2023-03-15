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
    public class BLInstructor
    {
        private readonly IGenericRepo<Instructor> instructorRepo;
        private readonly IMapper mapper;

        public BLInstructor(IGenericRepo<Instructor> _instructorRepo,IMapper _mapper)
        {
            instructorRepo = _instructorRepo;
            mapper = _mapper;
        }
        public List<InstructorViewModel> GetAll()
        {
            var instructorList= instructorRepo.GetAll().Include(dept=>dept.Department).ToList();
            var instructorVMList = mapper.Map< List<Instructor>,List<InstructorViewModel>>(instructorList);
            return instructorVMList;
        }
        public InstructorViewModel GetByID(int id)
        {
            var instructor = instructorRepo.GetAll().Include(dept => dept.Department).FirstOrDefault(a=>a.id==id);
            var instructorVM = mapper.Map<Instructor, InstructorViewModel>(instructor);
            return instructorVM;
        }
        public InstructorViewModel GetByIDNoTracking(int id)
        {
            var instructor = instructorRepo.GetAll().Where(a => a.id == id).AsNoTracking().ToList().FirstOrDefault();
            var instructorVM = mapper.Map<Instructor, InstructorViewModel>(instructor);
            return instructorVM;
        }
        public  void Delete(int id)
        {
            instructorRepo.Delete(id);
        }
        public  InstructorViewModel Update(InstructorViewModel entity)
        {
            var instructor = mapper.Map<InstructorViewModel, Instructor>(entity);
            instructorRepo.Update(instructor);
            return entity;
        }
        public InstructorViewModel Insert(InstructorViewModel entity)
        {
            var instructor = mapper.Map<InstructorViewModel, Instructor>(entity);
            instructorRepo.Insert(instructor);
            return entity;
        }
    }
}
