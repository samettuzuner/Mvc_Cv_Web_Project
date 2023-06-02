﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.Ajax.Utilities;
using Mvc_Cv_Project.Models.Entity;

namespace Mvc_Cv_Project.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities db = new DbCvEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();

        }

        public void Add(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void Delete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);

        }
        public void TUpdate(T p)
        {

            db.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}