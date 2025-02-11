using FreshVegCart.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreshVegCart.Api.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Primary Key
        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd(); // Auto-generate the Id on add

        builder.Property(p => p.Name)
            .IsRequired() // Name is required
            .HasMaxLength(200); // Maximum length of 200 characters

        builder.Property(p => p.ImageUrl)
            .HasMaxLength(500); // Maximum length of 500 characters

        builder.Property(p => p.Unit)
            .IsRequired() // Unit is required
            .HasMaxLength(50); // Maximum length of 50 characters

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18, 2)") // Configure the precision and scale for Price
            .IsRequired(); // Price is required

        builder.Property(p => p.IsActive)
            .HasDefaultValue(true); // Default value for IsActive is true

        builder.Property(p => p.IsDeleted)
            .HasDefaultValue(false); // Default value for IsDeleted is false

        // Table Name (Optional)
        builder.ToTable("Products");
    }
}