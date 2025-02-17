using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Data.Repositories;

public class OrderRepository(FreshVegCartDbContext dbContext) : BaseRepository<Order>(dbContext), IOrderRepository
{

    public override async Task<Order?> GetByIdAsync(long id) => await dbContext.Orders.Include(x => x.OrderItems).FirstOrDefaultAsync(x =>  x.Id == id);
    
}
