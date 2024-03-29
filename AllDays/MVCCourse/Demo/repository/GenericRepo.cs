﻿using Day2.interfaces;
using Day2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day2.repository
{
    public class GenericRepo<T>  : IGenericRepo<T> where T : class
    {
        private readonly DBHelper db;
        public GenericRepo(DBHelper _db)
        {
            db = _db;
        }
        public void Delete(int id)
        {
            db.Set<T>().Remove(GetByID(id));
            db.SaveChanges();
        }
        public void DeleteAll()
        {
            db.Set<T>().RemoveRange(GetAll());
            db.SaveChanges();
        }
        public  IQueryable<T> GetAll()
        {
            return db.Set<T>().AsQueryable();
        }
        public  T GetByID(int id)
        {
            return db.Set<T>().Find(id);
        }
        public T GetByName(string name)
        {
            return db.Set<T>().Find(name);
        }
        public  T GetLastID()
        {
            return db.Set<T>().Max();
        }
        public  T Insert(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
            return entity;
        }
        public  T Update(T entity)
        {
           // db.Set<T>().Attach(entity);
           // db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.Set<T>().Update(entity);
            db.SaveChanges();
            return entity;
        }
    }
}
