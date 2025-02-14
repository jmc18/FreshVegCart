using FreshVegCart.Shared.Enums;

namespace FreshVegCart.Api.Data.Entities;

public class Order
{
    public long Id { get; set; }
    public Guid UserId { get; set; }
    public Guid AddressId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Notes { get; set; }
    public string Status { get; set; } = nameof(OrderStatus.Placed);
    public string AddressName { get; set; }
    public int TotalItems { get; set; }



    //Navigation Properties
    public virtual User User { get; set; } = null!;
    public virtual ICollection<OrderItem> OrderItems { get; set; } = [];
    public virtual UserAddress Address { get; set; } = null!;
}