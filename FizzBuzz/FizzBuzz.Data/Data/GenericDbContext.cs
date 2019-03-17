using FizzBuzz.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FizzBuzz.Data
{
    public class GenericDbContext : DbContext
    {
        private static bool created = false;
        public GenericDbContext(DbContextOptions options) : base(options)
        {
            if (!created)
            {
                Database.EnsureCreated();
                created = true;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FizzBuzzLog<int>>().ToTable("FizzBuzzLog");
        }
    }
}
