using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;

namespace FreshVegCart.Api.Data.Repositories;

public class UserAddressRepository(FreshVegCartDbContext dbContext) : BaseRepository<UserAddress>(dbContext), IUserAddressRepository
{
}
