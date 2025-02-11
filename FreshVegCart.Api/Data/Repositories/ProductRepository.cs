using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Data.Repositories;

public class ProductRepository(FreshVegCartDbContext dbContext) : BaseRepository<Product>(dbContext), IProductRepository
{

    public async Task<Product[]> GetProductsByStatusAsync(bool isActive, bool isDeleted = false) 
        => await dbContext.Products.AsNoTracking().Where(p => p.IsActive == isActive && p.IsDeleted == isDeleted).ToArrayAsync();
    
}
