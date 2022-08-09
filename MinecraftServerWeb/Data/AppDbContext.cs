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

            modelBuilder.Entity<Post>()
                .Property(e => e.DateCreated)
                .IsRequired()
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Post>()
                .Property(e => e.AuthorId)
                .IsRequired()
                .HasMaxLength(450)
                .HasColumnType("nvarchar");

            modelBuilder.Entity<Announcement>()
                .Property(e => e.Description)
                .HasMaxLength(2000);
        }

    }
}