using AutoMapper;
using FreshVegCart.Api.Interfaces.Persistence;
using FreshVegCart.Api.Interfaces.Services;
using FreshVegCart.Shared.Dtos;

namespace FreshVegCart.Api.Services;

public class ProductService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductService> logger) : BaseService<ProductService>(unitOfWork, mapper, logger), IProductService
{
    public async Task<ProductDto[]> GetProductsAsync()
    {
        return await ExecuteAsync(async () =>
        {
            var products = await UnitOfWork.Products.GetProductsByStatusAsync(true);
            return Mapper.Map<ProductDto[]>(products);
        }, "An error occurred while retrieving products.");
    }
}