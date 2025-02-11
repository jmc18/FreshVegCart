using FreshVegCart.Api.Data.Configurations;
using FreshVegCart.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Data;

public class FreshVegCartDbContext(DbContextOptions<FreshVegCartDbContext> options) : DbContext(options)
{
    public virtual DbSet<Order> Orders { get; set; } = null!;
    public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<UserAddress> UserAddresses { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserAddressConfiguration());
    }
}
