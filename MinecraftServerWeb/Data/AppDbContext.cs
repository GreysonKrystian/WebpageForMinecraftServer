using Microsoft.EntityFrameworkCore;
using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Nickname)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(e => e.DateCreated)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(e => e.Rank)
                .HasMaxLength(200)
                .HasColumnType("varchar")
                .HasDefaultValue("User");
        }

    }
}