using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Shared.Dtos;

public class RegisterDto
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;
    //[RegularExpression("^d{10}$", ErrorMessage = "Invalid mobile number")]
    public string? Mobile { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = null!;
}