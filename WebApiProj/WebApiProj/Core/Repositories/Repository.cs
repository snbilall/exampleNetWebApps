using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebApiProj.Core.Abstract;
using Microsoft.EntityFrameworkCore;

namespace WebApiProj.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }
        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public List<T> Where(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }
    }
}
