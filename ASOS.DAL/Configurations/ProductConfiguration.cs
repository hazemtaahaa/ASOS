using ASOS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASOS.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(o => o.Rate)
                   .HasColumnType("decimal(18,2)");

            builder.Property(o => o.Price)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(p => p.Price)
                .IsRequired();

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId);

            builder.HasOne(p => p.Brand)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.BrandId);

            builder.HasOne(p => p.ProductType)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.ProductTypeId);

            builder.HasMany(p => p.ProductImages)
                     .WithOne(pi => pi.Product)
                     .HasForeignKey(pi => pi.ProductId);

            builder.HasMany(p => p.WishListProducts)
                   .WithOne(wp => wp.Product)
                     .HasForeignKey(wp => wp.ProductId);
        }


    }
}
