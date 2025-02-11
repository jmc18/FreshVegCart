using FreshVegCart.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreshVegCart.Api.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        // Composite Primary Key
        builder.HasKey(oi => new { oi.OrderId, oi.ProductId });

        // Properties
        builder.Property(oi => oi.ProductName)
            .IsRequired() // ProductName is required
            .HasMaxLength(200); // Maximum length of 200 characters

        builder.Property(oi => oi.ProductPrice)
            .HasColumnType("decimal(18, 2)") // Configure the precision and scale for ProductPrice
            .IsRequired(); // ProductPrice is required

        builder.Property(oi => oi.Quantity)
            .IsRequired(); // Quantity is required

        builder.Property(oi => oi.ProductImage)
            .HasMaxLength(500); // Maximum length of 500 characters

        builder.Property(oi => oi.Unit)
            .IsRequired() // Unit is required
            .HasMaxLength(50); // Maximum length of 50 characters

        // Navigation Properties
        builder.HasOne(oi => oi.Order) // Many-to-one relationship with Order
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete OrderItems when Order is deleted

        // If you uncomment the Product navigation property, configure it like this:
        // builder.HasOne(oi => oi.Product) // Many-to-one relationship with Product
        //        .WithMany()
        //        .HasForeignKey(oi => oi.ProductId)
        //        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        // Table Name (Optional)
        builder.ToTable("OrderItems");
    }
}
