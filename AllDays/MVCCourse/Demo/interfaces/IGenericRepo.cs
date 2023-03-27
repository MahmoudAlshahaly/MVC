using Day2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.interfaces
{
    public interface IGenericRepo<T> where T :class
    {
        IQueryable<T> GetAll();
        T GetByID(int id);
        T GetByName(string name);
        T GetLastID();
        T Insert(T entity);
        T Update(T entity);
        void Delete(int id);
        void DeleteAll();
    }
}
