using ASOS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ASOS.DAL.Configurations
{
    public class CartItemsConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => new { ci.CartId, ci.ProductId });
            builder.HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);
            builder.HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId);
        }


    }
}
