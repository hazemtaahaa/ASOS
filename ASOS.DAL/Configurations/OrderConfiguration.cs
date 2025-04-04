using ASOS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASOS.DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.TotalAmount)
                   .HasColumnType("decimal(18,2)");

            builder.HasMany(o => o.OrderItems)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(oi => oi.OrderId);

            builder.HasOne(o => o.UserOrderPayment)
                   .WithOne(uop => uop.Order)
                   .HasForeignKey<UserOrderPayment>(uop => uop.OrderId);
        }
    }
}
