using ASOS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ASOS.DAL.Configurations
{
    public class WishListProductConfiguration : IEntityTypeConfiguration<WishListProduct>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WishListProduct> builder)
        {
            builder.HasKey(wp => new { wp.ProductId, wp.WishListId });

            builder.HasOne(wp => wp.WishList)
                .WithMany(w => w.WishListProducts)
                .HasForeignKey(wp => wp.WishListId);

            builder.HasOne(wp => wp.Product)
                .WithMany(p => p.WishListProducts)
                .HasForeignKey(wp => wp.ProductId);
        }

    }
}
