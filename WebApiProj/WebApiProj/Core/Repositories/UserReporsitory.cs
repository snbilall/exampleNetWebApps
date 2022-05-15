using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiProj.Core.Abstract;
using WebApiProj.DbContexts;
using WebApiProj.Models;

namespace WebApiProj.Core.Repositories
{
    public class UserReporsitory : Repository<User>, IUserRepository
    {
        public UserReporsitory(AppDbContext context) : base(context)
        {
        }

        public List<User> HasTodoUsers()
        {
            var usrs = (from users in context.Set<User>()
                       join userTodos in context.Set<UserTodo>() on users.Id equals userTodos.UserId
                       where (from userTodos in context.Set<UserTodo>() where userTodos.UserId == users.Id select userTodos).Count() > 0
                       select users).ToList();
            return usrs;
        }
    }
}
