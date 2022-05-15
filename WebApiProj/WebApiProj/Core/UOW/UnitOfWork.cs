using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Core.Abstract;
using WebApiProj.Core.Repositories;
using WebApiProj.DbContexts;

namespace WebApiProj.Core.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public IUserRepository Users { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public ITodoRepository Todoes { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            Users = new UserReporsitory(context);
            Categories = new CategoryRepository(context);
            Todoes = new TodoRepository(context);
            
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
