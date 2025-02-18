using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Data.Repositories;

public class UserRepository(FreshVegCartDbContext dbContext) : BaseRepository<User>(dbContext), IUserRepository
{
    private readonly FreshVegCartDbContext _dbContext = dbContext;

    public async Task<User?> GetByEmailAsync(string email) =>
        await _dbContext.Users.FirstOrDefaultAsync(u => !string.IsNullOrEmpty(u.Email) && u.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
}
