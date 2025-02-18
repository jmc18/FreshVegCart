using System.Security.Claims;
using FreshVegCart.Api.ExtensionMethods;
using FreshVegCart.Api.Interfaces.Services;
using FreshVegCart.Shared.Dtos;
using FreshVegCart.Shared.RecordResults;
using Microsoft.AspNetCore.Mvc;


namespace FreshVegCart.Api.Endpoints;

public static class OrderEndpoints
{
    public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var orderGroup = endpoints.MapGroup("/api/orders")
            .RequireAuthorization()
            .WithTags("Orders");

        orderGroup.MapPost("/place-order",
                async ([FromBody] PlaceOrderDto dto, [FromServices] IOrderService orderService, [FromServices]ClaimsPrincipal principal) 
                    => Results.Ok(await orderService.PlaceOrderAsync(dto, (Guid)principal.GetUserId())))
            .Produces<ApiResult>()
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .WithName("Place-Order");

        orderGroup.MapGet("/users/{userId:Guid}/place-order",
                async ([FromRoute] Guid userId, [FromQuery]int startIndex, [FromQuery]int pageSize, [FromServices] IOrderService orderService, [FromServices] ClaimsPrincipal principal) =>
                {
                    if (userId != (Guid)principal.GetUserId()) return Results.Unauthorized();
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    var orders = await orderService.GetOrdersByUserIdAsync(userId, startIndex, pageSize);
                    return Results.Ok(orders);
                })
            .Produces<OrderDto[]>()
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .WithName("Orders By User Id");

        orderGroup.MapGet("/users/{userId:Guid}/orders/{orderId:long}/items",
                async ([FromRoute] Guid userId, [FromQuery] long orderId, [FromServices] IOrderService orderService, [FromServices] ClaimsPrincipal principal) =>
                {
                    if (userId != (Guid)principal.GetUserId()) return Results.Unauthorized();
                    var orders = await orderService.GetOrderItemsByOrderIdAsync(orderId, userId);
                    return Results.Ok(orders);
                })
            .Produces<OrderDto>()
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .WithName("Orders Order Items");

        return endpoints;
    }
}