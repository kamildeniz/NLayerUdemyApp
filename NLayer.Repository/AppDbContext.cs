using Microsoft.EntityFrameworkCore;

using NLayer.Core.Models;
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
        public override int SaveChanges()
        {

            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferece)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferece.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReferece).Property(x => x.CreatedDate).IsModified = false;

                                entityReferece.UpdatedDate = DateTime.Now;
                                break;
                            }
                        default:
                            break;
                    }
                }

            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferece)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferece.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReferece).Property(x => x.CreatedDate).IsModified = false;

                                entityReferece.UpdatedDate = DateTime.Now;
                                break;
                            }
                        default:
                            break;
                    }
                }

            }


            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Width = 100,
                Height = 200,
                ProductId = 1
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
