using Microsoft.EntityFrameworkCore;
using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Announcement> Announcements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Nickname)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(e => e.DateCreated)
                .IsRequired()
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<User>()
                .Property(e => e.Rank)
                .HasMaxLength(200)
                .HasColumnType("varchar")
                .HasDefaultValue("User");

            modelBuilder.Entity<Post>()
                .Property(e => e.DateCreated)
                .IsRequired()
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Post>()
                .HasOne(e => e.Author)
                .WithMany(e => e.Posts);
            modelBuilder.Entity<Post>()
                .Property(e => e.AuthorId)
                .IsRequired();
        }

    }
}