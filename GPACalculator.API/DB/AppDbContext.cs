using GPACalculator.API.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace GPACalculator.API.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<SubjectEntity> Subjects { get; set; }
        public DbSet<GradeEntity> Grades { get; set; }

        public AppDbContext(DbContextOptions options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating (builder);
        }
    }
}
