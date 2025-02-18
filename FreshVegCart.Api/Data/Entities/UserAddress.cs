namespace FreshVegCart.Api.Data.Entities;

public class UserAddress
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public bool IsDefault { get; set; }

    public bool IsDeleted { get; set; }



    #region Navigation Properties

    public virtual ICollection<Order> Orders { get; set; } = [];
    public virtual User User { get; set; } = null!;

    #endregion
}
