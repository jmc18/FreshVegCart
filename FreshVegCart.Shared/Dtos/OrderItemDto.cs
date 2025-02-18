namespace FreshVegCart.Shared.Dtos;

public class OrderItemDto
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public required string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int Quantity { get; set; }
    public string ProductImage { get; set; } = null!;
    public string Unit { get; set; } = null!;
}
