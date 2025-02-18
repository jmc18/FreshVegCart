using System.ComponentModel.DataAnnotations;

namespace FreshVegCart.Shared.Dtos;

public class LoginDto
{
    [Required(ErrorMessage = "Username is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = null!;
}