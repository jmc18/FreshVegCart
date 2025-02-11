namespace FreshVegCart.Shared.Dtos;

public class ProductDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Unit { get; set; }
    public decimal Price { get; set; }
}
