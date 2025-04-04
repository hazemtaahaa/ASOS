using ASOS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASOS.DAL.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);


            builder.HasOne(c => c.User)
                   .WithOne(u => u.Cart)
                   .HasForeignKey<Cart>(u => u.UserId);
        }
    }
}
