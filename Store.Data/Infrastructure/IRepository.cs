﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entiry);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate);
    }
}
