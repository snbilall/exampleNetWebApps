using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProj.Core.Abstract;

namespace WebApiProj.Core.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }
        ITodoRepository Todoes { get; }
        int Complete();
    }
}
