using Microsoft.EntityFrameworkCore;
using DDDFirst.Domain.Entities;

namespace DDDFirst.Infrastructure.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}
