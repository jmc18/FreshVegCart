using FreshVegCart.Shared.Dtos;
using FreshVegCart.Shared.RecordResults;
using Refit;

namespace FreshVegCart.App.Apis;

[Headers("Authorization: Bearer ")]
public interface IOrderApi
{
    [Post("api/orders/place-order")]
    Task<ApiResult> PlaceOrderAsync(PlaceOrderDto dto, Guid userId);
    [Get("api/orders/users/{userId}/place-order")]
    Task<ApiResult<OrderDto[]>> GetOrdersByUserIdAsync(Guid userId, int startIndex, int pageSize = 10);
    [Get("api/orders/users/{userId}/orders/{orderId}/items")]
    Task<ApiResult<OrderDto>> GetOrderItemsByOrderIdAsync(long orderId, Guid userId);
}