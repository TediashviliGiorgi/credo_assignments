using Microsoft.EntityFrameworkCore;
using MovieDatabase.API.DB.Entities;
using MovieDatabase.API.Mappings;

namespace MovieDatabase.API.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<MovieEntity> Movies { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MovieMap());

            base.OnModelCreating(builder);
        }
    }
}
