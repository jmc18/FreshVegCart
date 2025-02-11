using FreshVegCart.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreshVegCart.Api.Data.Configurations;

public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        // Primary Key
        builder.HasKey(ua => ua.Id);

        // Properties
        builder.Property(ua => ua.Id)
            .ValueGeneratedOnAdd(); // Auto-generate the Id on add

        builder.Property(ua => ua.UserId)
            .IsRequired(); // UserId is required

        builder.Property(ua => ua.Name)
            .IsRequired() // Name is required
            .HasMaxLength(100); // Maximum length of 100 characters

        builder.Property(ua => ua.Address)
            .IsRequired() // Address is required
            .HasMaxLength(500); // Maximum length of 500 characters

        builder.Property(ua => ua.IsDefault)
            .HasDefaultValue(false); // Default value for IsDefault is false

        builder.Property(ua => ua.IsDeleted)
            .HasDefaultValue(false); // Default value for IsDeleted is false

        // Navigation Properties
        builder.HasOne(ua => ua.User) // Many-to-one relationship with User
            .WithMany(u => u.UserAddresses)
            .HasForeignKey(ua => ua.UserId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        builder.HasMany(ua => ua.Orders) // One-to-many relationship with Order
            .WithOne(o => o.Address)
            .HasForeignKey(o => o.AddressId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        // Table Name (Optional)
        builder.ToTable("UserAddresses");
    }
}