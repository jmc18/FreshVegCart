using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;

namespace FreshVegCart.Api.Data.Repositories;

public class OrderItemRepository(FreshVegCartDbContext dbContext) : BaseRepository<OrderItem>(dbContext), IOrderItemRepository
{
}
