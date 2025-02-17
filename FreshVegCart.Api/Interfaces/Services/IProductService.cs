using FreshVegCart.Shared.Dtos;

namespace FreshVegCart.Api.Interfaces.Services;

public interface IProductService
{
    Task<ProductDto[]> GetProductsAsync();
}