using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MovieDatabase.API.DB.Entities;

namespace GPACalculator.API.DB
{
    public class AppDbContext : DbContext
    {
        DbSet<StudentEntity> Students { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
