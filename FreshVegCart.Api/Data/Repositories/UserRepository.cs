using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;

namespace FreshVegCart.Api.Data.Repositories;

public class UserRepository(FreshVegCartDbContext dbContext) : BaseRepository<User>(dbContext), IUserRepository
{
}
