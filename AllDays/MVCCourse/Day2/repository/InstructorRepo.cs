using Day2.interfaces;
using Day2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.repository
{
    public class InstructorRepo : IInstructorRepo
    {
        private readonly DBHelper db;

        public InstructorRepo(DBHelper _db)
        {
            db = _db;
        }
        public List<Instructor> GetAll()
        {
            return db.instructors.ToList();
        }

        public Instructor GetByID(int ID)
        {
            return db.instructors.Find(ID);
        }
    }
}
