using System;
using Microsoft.EntityFrameworkCore;
using MyVolunteerDAL.Entities;

namespace MyVolunteerDAL.Context
{
    public class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options =
            new DbContextOptionsBuilder<InMemoryContext>()
                .UseInMemoryDatabase("TheDB")
                .Options;

        public InMemoryContext() : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
