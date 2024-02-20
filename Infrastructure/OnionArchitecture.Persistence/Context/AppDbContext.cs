﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnionArchitecture.Domain.Entites;
using System.Reflection;

namespace OnionArchitecture.Persistence.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
