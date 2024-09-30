using System;
using EGRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace EGRepositoryPattern
{
	public class ApplicationDbContext : DbContext
	{
        private readonly ApplicationDbContext _dbContext;
        public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "ABCD" },
                new Product { Id = 2, Name = "EFG" }
             
                );
        }
        }
}

