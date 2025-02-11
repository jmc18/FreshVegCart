using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;

namespace FreshVegCart.Api.Data.Repositories;

public class OrderRepository(FreshVegCartDbContext dbContext) : BaseRepository<Order>(dbContext), IOrderRepository
{
}
