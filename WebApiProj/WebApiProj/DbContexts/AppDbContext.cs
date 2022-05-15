using Microsoft.EntityFrameworkCore;
using WebApiProj.Models;

namespace WebApiProj.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTodo>().HasKey(sc => new { sc.TodoId, sc.UserId });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTodo> UserTodos { get; set; }
    }
}
