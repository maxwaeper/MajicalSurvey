﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MajicalSurvey.Data
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private Context _context;

        public Repository()
        {
            _context = new Context();
        }

        public virtual List<T> GetAllElements()
        { 
            return _context.Set<T>().ToList();
        }

        public virtual IQueryable<T> GetCertainElement(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var entity = _context.Set<T>().Find(predicate);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}