﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinecraftServerWeb.Models;

namespace MinecraftServerWeb.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Announcement> Announcements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>()
                .Property(e => e.ServerNickname)
                .HasColumnType("varchar")
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(e => e.ForumNickname)
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
            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithOne(e => e.Author)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithOne(e => e.Author)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
                .Property(e => e.DateCreated)
                .IsRequired()
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Post>()
                .Property(e => e.AuthorId)
                .IsRequired()
                .HasMaxLength(450)
                .HasColumnType("nvarchar");
            modelBuilder.Entity<Post>()
                .HasMany(e => e.Comments)
                .WithOne(e => e.Post)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Announcement>()
                .Property(e => e.Description)
                .HasMaxLength(3000);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Content)
                .HasMaxLength(1500);
            modelBuilder.Entity<Comment>()
                .Property(e => e.Rating)
                .HasDefaultValue(0);
        }

    }
}