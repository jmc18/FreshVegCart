﻿using FreshVegCart.Api.Data.Entities;

namespace FreshVegCart.Api.Interfaces.Persistence.Repositories;

public interface IOrderRepository : IAsyncRepository<Order>
{
    Task<Order[]> GetOrdersByUserIdAsync(Guid userId);
}
