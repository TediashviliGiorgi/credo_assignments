using BonusManagementSystem.API.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace BonusManagementSystem.API.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<BonusEntity> Bonuces { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
