using AutoMapper;
using FreshVegCart.Api.Interfaces.Persistence;
using FreshVegCart.Shared.Dtos;

namespace FreshVegCart.Api.Services;

public class ProductService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductService> logger)
{
    public async Task<ProductDto[]> GetProductsAsync()
    {
        try
        {
            var products = await unitOfWork.Products.GetProductsByStatusAsync(true);

            return mapper.Map<ProductDto[]>(products);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while retrieving products.\nMessage: {message}\nStackTrace: {stackTrace}", ex.Message, ex.StackTrace);
            return [];
        }
    }
}

public class AuthService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AuthService> logger)
{

}
