namespace FreshVegCart.Api.Data.Entities;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string Unit { get; set; } = null!;
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
