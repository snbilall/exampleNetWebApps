using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Core.Abstract;
using WebApiProj.Models;

namespace WebApiProj.Core.Abstract
{
    public interface ITodoRepository : IRepository<Todo>
    {
        List<Todo> DoneTodos();
    }
}
