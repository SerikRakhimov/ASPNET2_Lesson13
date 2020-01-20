﻿using SaveTime.DaraAccess;
using SaveTime.DataModel.Marker;
using SaveTime.DataModel.Organization;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SaveTime.Web.Admin.Repo.Impl
{
    public class Repository<T>: IRepository<T> where T:class, IEntity
    {
        private SaveTimeModel context = new SaveTimeModel();
        public void Create(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
        }
      
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T GetById(int? id)
        {
            return context.Set<T>().FirstOrDefault(t => t.Id == id);
        }

        public T GetByIdInclude(int? id, string fieldName)
        {
            T branch = context.Set<T>()
                   .Include(fieldName)
                   .FirstOrDefault(t => t.Id == id);

            return branch;
        }

        public void Edit(T item)
        {
            context.Entry<T>(item).State = EntityState.Modified;

            context.SaveChanges();
        }
   

        public void Remove(T item)
        {
            context.Set<T>().Remove(item);
            context.SaveChanges();
        }

    }
}