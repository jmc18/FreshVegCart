using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Data.Repositories;

public class ProductRepository(FreshVegCartDbContext dbContext) : BaseRepository<Product>(dbContext), IProductRepository
{

    public async Task<Product[]> GetProductsByStatusAsync(bool isActive, bool isDeleted = false) 
        => await dbContext.Products.AsNoTracking().Where(p => p.IsActive == isActive && p.IsDeleted == isDeleted).ToArrayAsync();

    public async Task<Dictionary<long, Product>> GetProductsByIdsAsync(IEnumerable<long> productIds)
    {
        var products = await dbContext.Products.Where(p => productIds.Contains(p.Id)).ToDictionaryAsync(p => p.Id);
        return products;
    }
    
}
