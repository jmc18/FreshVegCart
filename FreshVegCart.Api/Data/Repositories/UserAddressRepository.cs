using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Data.Repositories;

public class UserAddressRepository(FreshVegCartDbContext dbContext) : BaseRepository<UserAddress>(dbContext), IUserAddressRepository
{
    private readonly FreshVegCartDbContext _dbContext = dbContext;

    public async Task UnsetDefaultAddress(Guid userId)
    {
        var userAddress = await _dbContext.UserAddresses.Where(x => x.UserId == userId && x.IsDefault).ToArrayAsync();
        if (userAddress.Length > 0)
        {
            foreach (var address in userAddress)
            {
                address.IsDefault = false;
                await UpdateAsync(address);
            }
        }
    }

    public async Task<UserAddress[]> GetUserAddressesAsync(Guid userId, bool isActive = true) => await _dbContext.UserAddresses.Where(x => x.UserId == userId && x.IsDeleted == !isActive).ToArrayAsync();
}
