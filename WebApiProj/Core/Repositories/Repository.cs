using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebApiProj.Core.Abstract;

namespace WebApiProj.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }
        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }
    }
}
