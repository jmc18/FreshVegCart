using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Data.Repositories;

public class UserAddressRepository(FreshVegCartDbContext dbContext) : BaseRepository<UserAddress>(dbContext), IUserAddressRepository
{
    public async Task UnsetDefaultAddress(Guid userId)
    {
        var userAddress = await dbContext.UserAddresses.Where(x => x.UserId == userId && x.IsDefault).ToArrayAsync();
        if (userAddress.Length > 0)
        {
            foreach (var address in userAddress)
            {
                address.IsDefault = false;
                await UpdateAsync(address);
            }
        }
    }

    public async Task<UserAddress[]> GetUserAddressesAsync(Guid userId, bool isActive = true) => await dbContext.UserAddresses.Where(x => x.UserId == userId && x.IsDeleted == !isActive).ToArrayAsync();
}
