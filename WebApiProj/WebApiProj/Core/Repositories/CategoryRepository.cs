using Microsoft.EntityFrameworkCore;
using WebApiProj.Core.Abstract;
using WebApiProj.DbContexts;
using WebApiProj.Models;

namespace WebApiProj.Core.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
