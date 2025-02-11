namespace FreshVegCart.Api.Data.Entities;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Unit { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}
