using ASOS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASOS.DAL.Configurations
{
    public class UserOrderPaymentConfiguration : IEntityTypeConfiguration<UserOrderPayment>
    {
        public void Configure(EntityTypeBuilder<UserOrderPayment> builder)
        {
            builder.HasKey(uop => uop.Id );

            builder
                .HasOne(uop => uop.User)
                .WithMany(u => u.UserOrderPayments)
                .HasForeignKey(uop => uop.UserId);

            builder
                .HasOne(uop => uop.Order)
                .WithOne(o => o.UserOrderPayment)
                .HasForeignKey<UserOrderPayment>(uop => uop.OrderId);

            builder
                .HasOne(uop => uop.Payment)
                .WithOne(p => p.UserOrderPayment)
                .HasForeignKey<UserOrderPayment>(uop => uop.PaymentId);
        }
    }

}
