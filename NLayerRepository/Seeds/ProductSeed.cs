using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayerRepository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                Price = 100,
                Stock = 20,
                CreateDate = DateTime.Now,
                Name = "Pencil 1"
            },
            new Product
            {
                Id = 2,
                CategoryId = 1,
                Price = 200,
                Stock = 30,
                CreateDate = DateTime.Now,
                Name = "Pencil 2"
            },
            new Product
            {
                Id = 3,
                CategoryId = 1,
                Price = 600,
                Stock = 50,
                CreateDate = DateTime.Now,
                Name = "Pencil 3"
            },
            new Product
            {
                Id = 4,
                CategoryId = 2,
                Price = 200,
                Stock = 30,
                CreateDate = DateTime.Now,
                Name = "Book 1"
            }
            ,
            new Product
            {
                Id = 5,
                CategoryId = 2,
                Price = 300,
                Stock = 30,
                CreateDate = DateTime.Now,
                Name = "Book 2"
            });
        }
    }
}
