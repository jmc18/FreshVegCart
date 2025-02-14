using FreshVegCart.Shared.Enums;

namespace FreshVegCart.Shared.Dtos;

public class OrderDto
{
    public long Id { get; set; }
    public Guid AddressId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Notes { get; set; }
    public string Status { get; set; }
    public string Address { get; set; }
    public string AddressName { get; set; }
    public int TotalItems { get; set; }
}