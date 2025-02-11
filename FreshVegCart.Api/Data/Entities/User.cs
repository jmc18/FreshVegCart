namespace FreshVegCart.Api.Data.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public string? PasswordHash { get; set; }
    public bool IsLocked { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }


    // Navigation Properties
    public virtual ICollection<Order> Orders { get; set; } = [];
    public virtual ICollection<UserAddress> UserAddresses { get; set; } = [];
}
