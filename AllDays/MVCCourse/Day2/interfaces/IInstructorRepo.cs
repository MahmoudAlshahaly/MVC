using Day2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.interfaces
{
    public interface IInstructorRepo
    {
       List<Instructor> GetAll();

        Instructor GetByID(int ID);
    }
}
