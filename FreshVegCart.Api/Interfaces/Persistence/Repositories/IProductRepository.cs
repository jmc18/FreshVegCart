using FreshVegCart.Api.Data.Entities;

namespace FreshVegCart.Api.Interfaces.Persistence.Repositories;

public interface IProductRepository : IAsyncRepository<Product>
{
    Task<Product[]> GetProductsByStatusAsync(bool isActive, bool isDeleted = false);
}
