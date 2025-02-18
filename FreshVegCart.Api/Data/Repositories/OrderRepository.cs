using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Data.Repositories;

public class OrderRepository(FreshVegCartDbContext dbContext) : BaseRepository<Order>(dbContext), IOrderRepository
{
    private readonly FreshVegCartDbContext _dbContext = dbContext;

    public override async Task<Order?> GetByIdAsync(long id) => await _dbContext.Orders.Include(x => x.OrderItems).FirstOrDefaultAsync(x =>  x.Id == id);
    public async Task<Order[]> GetOrdersByUserIdAsync(Guid userId) => await _dbContext.Orders.Where(x => x.UserId == userId).ToArrayAsync();
    
}
