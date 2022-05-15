using ExampleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleApp.ContextBase
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Director> Director { get; set; }
    }
}
