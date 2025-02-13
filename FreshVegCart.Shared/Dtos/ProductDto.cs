using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Shared.Dtos;

public class ProductDto
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    
    public string Unit { get; set; }
    public decimal Price { get; set; }

    public bool IsAddingOrEditing { get; set; }
}