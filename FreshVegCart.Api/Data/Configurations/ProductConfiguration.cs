using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Shared.Constants;
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

        builder.HasData(
        [
            new Product { Id = 1, Name = "Avocado", ImageUrl = $"{DataConstants.ImageUrlPrefix}avocado.png", Unit = "each", Price = 1.99m },
            new () { Id = 2, Name = "Beet", ImageUrl = $"{DataConstants.ImageUrlPrefix}beet.png", Unit = "each", Price = 0.99m },
            new () { Id = 3, Name = "Bell Pepper", ImageUrl = $"{DataConstants.ImageUrlPrefix}bell_pepper.png", Unit = "each", Price = 1.50m },
            new () { Id = 4, Name = "Broccoli", ImageUrl = $"{DataConstants.ImageUrlPrefix}broccoli.png", Unit = "each", Price = 2.00m },
            new () { Id = 5, Name = "Cabbage", ImageUrl = $"{DataConstants.ImageUrlPrefix}cabbage.png", Unit = "each", Price = 1.20m },
            new () { Id = 6, Name = "Capsicum", ImageUrl = $"{DataConstants.ImageUrlPrefix}capsicum.png", Unit = "each", Price = 1.80m },
            new () { Id = 7, Name = "Carrot", ImageUrl = $"{DataConstants.ImageUrlPrefix}carrot.png", Unit = "kg", Price = 0.80m },
            new () { Id = 8, Name = "Cauliflower", ImageUrl = $"{DataConstants.ImageUrlPrefix}cauliflower.png", Unit = "each", Price = 2.50m },
            new () { Id = 9, Name = "Coriander", ImageUrl = $"{DataConstants.ImageUrlPrefix}coriander.png", Unit = "bunch", Price = 0.70m },
            new () { Id = 10, Name = "Corn", ImageUrl = $"{DataConstants.ImageUrlPrefix}corn.png", Unit = "each", Price = 1.00m },
            new () { Id = 11, Name = "Cucumber", ImageUrl = $"{DataConstants.ImageUrlPrefix}cucumber.png", Unit = "each", Price = 0.90m },
            new () { Id = 12, Name = "Eggplant", ImageUrl = $"{DataConstants.ImageUrlPrefix}eggplant.png", Unit = "each", Price = 1.75m },
            new () { Id = 13, Name = "Farmer", ImageUrl = $"{DataConstants.ImageUrlPrefix}farmer.png", Unit = "each", Price = 5.00m },
            new () { Id = 14, Name = "Ginger", ImageUrl = $"{DataConstants.ImageUrlPrefix}ginger.png", Unit = "kg", Price = 2.20m },
            new () { Id = 15, Name = "Green Beans", ImageUrl = $"{DataConstants.ImageUrlPrefix}green_beans.png", Unit = "kg", Price = 1.60m },
            new () { Id = 16, Name = "Ladyfinger", ImageUrl = $"{DataConstants.ImageUrlPrefix}ladyfinger.png", Unit = "kg", Price = 1.10m },
            new () { Id = 17, Name = "Lettuce", ImageUrl = $"{DataConstants.ImageUrlPrefix}lettuce.png", Unit = "each", Price = 1.30m },
            new () { Id = 18, Name = "Mushroom", ImageUrl = $"{DataConstants.ImageUrlPrefix}mushroom.png", Unit = "kg", Price = 2.80m },
            new () { Id = 19, Name = "Onion", ImageUrl = $"{DataConstants.ImageUrlPrefix}onion.png", Unit = "kg", Price = 0.60m },
            new () { Id = 20, Name = "Pea", ImageUrl = $"{DataConstants.ImageUrlPrefix}pea.png", Unit = "kg", Price = 1.40m },
            new () { Id = 21, Name = "Potato", ImageUrl = $"{DataConstants.ImageUrlPrefix}potato.png", Unit = "kg", Price = 0.50m },
            new () { Id = 22, Name = "Pumpkin", ImageUrl = $"{DataConstants.ImageUrlPrefix}pumpkin.png", Unit = "each", Price = 3.00m },
            new () { Id = 23, Name = "Radish", ImageUrl = $"{DataConstants.ImageUrlPrefix}radish.png", Unit = "bunch", Price = 0.85m },
            new () { Id = 24, Name = "Red Chili", ImageUrl = $"{DataConstants.ImageUrlPrefix}red_chili.png", Unit = "kg", Price = 1.50m },
            new () { Id = 25, Name = "Spinach", ImageUrl = $"{DataConstants.ImageUrlPrefix}spinach.png", Unit = "bunch", Price = 1.20m },
            new () { Id = 26, Name = "Tomato", ImageUrl = $"{DataConstants.ImageUrlPrefix}tomato.png", Unit = "kg", Price = 0.95m },
            new () { Id = 27, Name = "Turnip", ImageUrl = $"{DataConstants.ImageUrlPrefix}turnip.png", Unit = "each", Price = 0.75m },
            new () { Id = 28, Name = "Vegetables", ImageUrl = $"{DataConstants.ImageUrlPrefix}vegetables.png", Unit = "each", Price = 4.00m },
            new () { Id = 29, Name = "Yellow Capsicum", ImageUrl = $"{DataConstants.ImageUrlPrefix}yellow_capsicum.png", Unit = "each", Price = 1.80m }
            ]);
    }
}