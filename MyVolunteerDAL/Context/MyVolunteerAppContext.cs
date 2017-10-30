using System;
using Microsoft.EntityFrameworkCore;
using MyVolunteerDAL.Entities;

namespace MyVolunteerDAL.Context
{
    public class MyVolunteerAppContext : DbContext
    {
        static DbContextOptions<MyVolunteerAppContext> options =
            new DbContextOptionsBuilder<MyVolunteerAppContext>()
                .UseInMemoryDatabase("TheDB")
                .Options;

        public MyVolunteerAppContext() : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuildUser>()
                        .HasKey(gu => new {gu.GuildId, gu.UserId});

            modelBuilder.Entity<GuildUser>()
                        .HasOne(gu => gu.Guild)
                        .WithMany(g => g.Users)
                        .HasForeignKey(gu => gu.GuildId);

            modelBuilder.Entity<GuildUser>()
                        .HasOne(gu => gu.User)
                        .WithMany(u => u.Guilds)
                        .HasForeignKey(gu => gu.UserId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Guild> Guilds { get; set; }
    }
}
