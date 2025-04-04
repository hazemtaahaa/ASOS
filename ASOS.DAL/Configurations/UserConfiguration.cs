using ASOS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASOS.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User"); 
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Address)
                .HasMaxLength(200);
            builder.Property(u => u.City)
                .HasMaxLength(100);
            builder.Property(u => u.Country)
                .HasMaxLength(100);

            builder.HasMany(u => u.UserOrderPayments)
                .WithOne(uop => uop.User)
                .HasForeignKey(uop => uop.UserId);

            builder.HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(u => u.UserId);

            builder.HasOne(u => u.WishList)
                   .WithOne(w => w.User)
                   .HasForeignKey<WishList>(u => u.UserId);
        }

    }
}
