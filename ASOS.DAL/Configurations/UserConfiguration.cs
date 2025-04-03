using ASOS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASOS.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Address)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(u => u.City)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Country)
                .IsRequired()
                .HasMaxLength(100);
        }

    }
}
