using ASOS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASOS.DAL.Configurations
{
    public class UserOrderPaymentConfiguration : IEntityTypeConfiguration<UserOrderPayment>
    {
        public void Configure(EntityTypeBuilder<UserOrderPayment> builder)
        {
            builder.HasKey(uop => new { uop.Id });

            builder
                .HasOne(uop => uop.User)
                .WithMany(u => u.UserOrderPayments)
                .HasForeignKey(uop => uop.UserId);

            builder
                .HasOne(uop => uop.Order)
                .WithMany(o => o.UserOrderPayments)
                .HasForeignKey(uop => uop.OrderId);

            builder
                .HasOne(uop => uop.Payment)
                .WithMany(p => p.UserOrderPayments)
                .HasForeignKey(uop => uop.PaymentId);
        }
    }

}
