using ASOS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASOS.DAL.Configurations
{
    public class WishListConfiguration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w => w.User)
                .WithOne(u => u.WishList)
                .HasForeignKey<WishList>(w =>  w.UserId);

            builder.HasMany(w => w.WishListProducts)
                .WithOne(wp => wp.WishList)
                .HasForeignKey(wp => wp.WishListId);    
        }
    }
}
