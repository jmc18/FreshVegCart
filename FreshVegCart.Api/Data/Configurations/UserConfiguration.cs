using FreshVegCart.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreshVegCart.Api.Data.Configurations
{

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table Name (Optional)
            builder.ToTable("Users");

            // Primary Key
            builder.HasKey(u => u.Id);

            // Properties
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .HasMaxLength(255);

            builder.Property(u => u.Mobile)
                .HasMaxLength(20);

            builder.Property(u => u.PasswordHash)
                .HasMaxLength(255);

            builder.Property(u => u.IsLocked)
                .HasDefaultValue(false);

            builder.Property(u => u.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(u => u.IsActive)
                .HasDefaultValue(true);

            // Navigation Properties
            builder.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserAddresses)
                .WithOne(ua => ua.User)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
