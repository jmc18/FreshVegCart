using FreshVegCart.Shared.Dtos;
using Refit;

namespace FreshVegCart.App.Apis;

public interface IProductApi
{
    [Get("/api/products/list")]
    Task<ProductDto[]> GetProductsAsync();
}