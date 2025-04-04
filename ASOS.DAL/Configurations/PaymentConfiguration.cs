using ASOS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASOS.DAL.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Amount).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.UserOrderPayment)
                .WithOne(uop => uop.Payment)
                .HasForeignKey<UserOrderPayment>(uop => uop.PaymentId);

           
        }
    }
}
