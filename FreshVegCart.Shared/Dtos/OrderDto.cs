using FreshVegCart.Shared.Enums;

namespace FreshVegCart.Shared.Dtos;

public class OrderDto
{
    public long Id { get; set; }
    public Guid AddressId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Notes { get; set; } = string.Empty;
    public string Status { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string AddressName { get; set; } = null!;
    public int TotalItems { get; set; }
}