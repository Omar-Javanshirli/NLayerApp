using Microsoft.EntityFrameworkCore;
using NLayer.Core.Model;
using System.Reflection;

namespace NLayerRepository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // yazdigimiz butun configuration-lari burda tanimagi ucun asagidaki kodu yazmlaiyiq;
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>()
                .HasData(new ProductFeature
                {
                    Id = 1,
                    Color = "Red",
                    Height = 100,
                    Width = 200,
                    ProductId = 1,
                },
                new ProductFeature
                {
                    Id = 2,
                    Color = "Blue",
                    Height = 200,
                    Width = 300,
                    ProductId = 2,
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
