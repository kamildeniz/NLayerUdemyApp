﻿using Microsoft.EntityFrameworkCore;

using NLayer.Core.Models;
using NLayer.Repository.Configurations;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color="Kırmızı",
                Width=100,
                Height=200,
                ProductId=1
            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Mavi",
                Width = 100,
                Height = 200,
                ProductId = 2
            }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
