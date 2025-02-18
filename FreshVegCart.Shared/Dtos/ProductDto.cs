using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Shared.Dtos;

public class ProductDto
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = null!;
    public string Unit { get; set; } = null!;
    public decimal Price { get; set; }
    public bool IsAddingOrEditing { get; set; }
}