using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApiProj.Core.Abstract
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        List<T> GetAll();
        List<T> Where(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
