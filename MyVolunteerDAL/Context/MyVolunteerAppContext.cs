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

        public DbSet<User> Users { get; set; }
        public DbSet<Guild> Guilds { get; set; }
    }
}
