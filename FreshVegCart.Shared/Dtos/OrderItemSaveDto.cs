using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Shared.Dtos;

public class OrderItemSaveDto
{
    [Required]
    public long ProductId { get; set; }
    [Required, Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}
