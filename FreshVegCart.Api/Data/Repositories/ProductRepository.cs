using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence.Repositories;

namespace FreshVegCart.Api.Data.Repositories;

public class ProductRepository(FreshVegCartDbContext dbContext) : BaseRepository<Product>(dbContext), IProductRepository
{
}
