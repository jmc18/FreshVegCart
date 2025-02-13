using FreshVegCart.Api.Data.Entities;

namespace FreshVegCart.Api.Interfaces.Persistence.Repositories;

public interface IUserAddressRepository : IAsyncRepository<UserAddress>
{
    Task UnsetDefaultAddress(Guid userId);
    Task<UserAddress[]> GetUserAddressesAsync(Guid userId, bool isActive = true);
}
