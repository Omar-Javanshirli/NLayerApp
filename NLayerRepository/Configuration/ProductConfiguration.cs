using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Model;

namespace NLayerRepository.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired().
                HasMaxLength(200);

            builder.Property(x => x.Stock)
                .IsRequired();

            builder.Property(x => x.Price).
                IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Category) // bir product-in bir dene Categorisi ola biler
                 .WithMany(x => x.Products) // Bir categorinin de birden cox categorisi ola biler
                 .HasForeignKey(x => x.CategoryId);
        }
    }
}
