using FizzBuzz.Entities;
using FizzBuzz.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FizzBuzz.Data
{
    public class FizzBuzzDbContext : DbContext
    {
        private static bool created = false;
        public FizzBuzzDbContext(DbContextOptions context) : base(context)
        {
            if (!created)
            {
                Database.EnsureCreated();
                created = true;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FizzBuzzHistory<int>>().ToTable("FizzBuzzHistory");
        }
    }
}
