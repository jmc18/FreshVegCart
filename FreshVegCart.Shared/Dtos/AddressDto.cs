using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Shared.Dtos;

public class AddressDto
{
    public Guid? Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }
    [Required(ErrorMessage = "Address is required")]
    public required string Address { get; set; }
    public bool IsDefault { get; set; }
}