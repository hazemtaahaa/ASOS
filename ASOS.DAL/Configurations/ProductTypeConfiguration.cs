using ASOS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ASOS.DAL.Configurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(pt => pt.Id);
            builder.Property(pt => pt.Name).IsRequired().HasMaxLength(50);
            builder.HasMany(pt => pt.Products)
                   .WithOne(p => p.ProductType)
                   .HasForeignKey(p => p.ProductTypeId);
        }

    }
}
