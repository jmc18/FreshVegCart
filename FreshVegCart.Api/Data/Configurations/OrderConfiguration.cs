using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Shared.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Primary Key
        builder.HasKey(o => o.Id);

        // Properties
        builder.Property(o => o.Id)
               .ValueGeneratedOnAdd(); // Auto-generate the Id on add

        builder.Property(o => o.UserId)
               .IsRequired(); // UserId is required

        builder.Property(o => o.AddressId)
               .IsRequired(); // AddressId is required

        builder.Property(o => o.OrderDate)
               .IsRequired(); // OrderDate is required

        builder.Property(o => o.TotalAmount)
               .HasColumnType("decimal(18, 2)") // Configure the precision and scale for TotalAmount
               .IsRequired(); // TotalAmount is required

        builder.Property(o => o.Notes)
               .HasMaxLength(500); // Maximum length of 500 characters
        builder.Property(o => o.AddressName).HasDefaultValue(string.Empty);
        builder.Property(o => o.TotalItems).HasDefaultValue(0);

        builder.Property(o => o.Status)
               .IsRequired() // Status is required
               .HasMaxLength(50) // Maximum length of 50 characters
               .HasDefaultValue(nameof(OrderStatus.Placed)); // Default value for Status is "Placed"

        // Navigation Properties
        builder.HasOne(o => o.User) // One-to-many relationship with User
               .WithMany(u => u.Orders)
               .HasForeignKey(o => o.UserId)
               .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        builder.HasOne(o => o.Address) // One-to-many relationship with UserAddress
               .WithMany()
               .HasForeignKey(o => o.AddressId)
               .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        builder.HasMany(o => o.OrderItems) // One-to-many relationship with OrderItem
               .WithOne(oi => oi.Order)
               .HasForeignKey(oi => oi.OrderId)
               .OnDelete(DeleteBehavior.Cascade); // Cascade delete OrderItems when Order is deleted

        // Table Name (Optional)
        builder.ToTable("Orders");
    }
}