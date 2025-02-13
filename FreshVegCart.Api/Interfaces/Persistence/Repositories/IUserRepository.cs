using FreshVegCart.Api.Data.Entities;

namespace FreshVegCart.Api.Interfaces.Persistence.Repositories;

public interface IUserRepository : IAsyncRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}
