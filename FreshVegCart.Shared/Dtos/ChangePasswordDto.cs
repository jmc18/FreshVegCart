using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FreshVegCart.Shared.Dtos;

public class ChangePasswordDto
{
    [Required(ErrorMessage = "Old password is required")]
    public string OldPassword { get; set; }
    [Required(ErrorMessage = "New password is required")]
    public string NewPassword { get; set; }
    [Required(ErrorMessage = "Confirm password is required"), Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
    [JsonIgnore]
    public string ConfirmPassword { get; set; }
}