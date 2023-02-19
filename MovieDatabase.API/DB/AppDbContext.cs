using Microsoft.EntityFrameworkCore;
using MovieDatabase.API.DB.Entities;

namespace MovieDatabase.API.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<MovieEntity> Movies { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
