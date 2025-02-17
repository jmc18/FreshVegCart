using FreshVegCart.Shared.Dtos;
using FreshVegCart.Shared.RecordResults;

namespace FreshVegCart.Api.Interfaces.Services;

public interface IOrderService
{
    Task<ApiResult> PlaceOrderAsync(PlaceOrderDto dto, Guid userId);
    Task<ApiResult<AddressDto[]>> GetUserOrdersAsync(Guid userId, int startIndex, int PageSize);
    Task<ApiResult<OrderDto>> GetOrderItemsByOrderIdAsync(long orderId, Guid userId);
}