using JwtApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtApp.Context
{
    public class PatikaJwtDbContext : DbContext
    {
        public PatikaJwtDbContext(DbContextOptions<PatikaJwtDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
