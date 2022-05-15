using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiProj.Core.Abstract;
using WebApiProj.DbContexts;
using WebApiProj.Models;

namespace WebApiProj.Core.Repositories
{
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        public TodoRepository(AppDbContext context) : base(context)
        {
        }

        public List<Todo> DoneTodos()
        {
            return context.Set<Todo>().Where(todo => todo.isDone == true).ToList();
        }
    }
}
