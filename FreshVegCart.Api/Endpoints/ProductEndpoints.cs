using FreshVegCart.Api.Interfaces.Services;
using FreshVegCart.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FreshVegCart.Api.Endpoints;

public static class ProductEndpoints
{
    private const string Endpoint = "/api/products";
    private const string TableName = "Products";


    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpoints)
    {

       endpoints
           .MapGet(Endpoint + "/list", async ([FromServices] IProductService productService) =>
            {
                var products = await productService.GetProductsAsync();
                return TypedResults.Ok(products);
            })
            .Produces<ProductDto[]>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .WithName("GetProductList")
            .WithTags(TableName);

        return endpoints;
    }
}