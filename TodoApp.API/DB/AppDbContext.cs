using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoApp.API.DB.Entities;

namespace TodoApp.API.DB
{
    public class AppDbContext : IdentityDbContext<UserEntity, RoleEntity, int>
    {
        public DbSet<SendEmailRequestEntity> SendEmailRequests { get; set; }
        public DbSet<TodoEntity> Todos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserEntity>().ToTable("users")
            .HasMany(d => d.Todos)
            .WithOne()
            .HasForeignKey(e => e.UserId);
            builder.Entity<TodoEntity>().ToTable("Todos");
            builder.Entity<RoleEntity>().ToTable("Roles");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles").HasKey(p => p.UserId);
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins").HasKey(p => p.UserId);
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens").HasKey(p => p.UserId);

        }
    }
}
