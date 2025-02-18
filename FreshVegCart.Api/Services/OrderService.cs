using AutoMapper;
using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence;
using FreshVegCart.Api.Interfaces.Services;
using FreshVegCart.Shared.Dtos;
using FreshVegCart.Shared.RecordResults;

namespace FreshVegCart.Api.Services;

public class OrderService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<OrderService> logger)
    : BaseService<OrderService>(unitOfWork, mapper, logger), IOrderService
{
    public async Task<ApiResult> PlaceOrderAsync(PlaceOrderDto dto, Guid userId)
    {
        return await ExecuteAsync(async () =>
        {
            if (dto.Items.Length == 0)
            {
                return ApiResult.Failure("No items in order.");
            }
            var productIds = dto.Items.Select(x => x.ProductId).ToHashSet();
            var products = await UnitOfWork.Products.GetProductsByIdsAsync(productIds);
            if (products.Count < dto.Items.Length)
            {
                return ApiResult.Failure("Some products were not found.");
            }
            var orderItems = dto.Items.Select(oi =>
            {
                var product = products[oi.ProductId];
                return new OrderItem
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    ProductImage = product.ImageUrl,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    Unit = product.Unit
                };
            }).ToArray();
            var currentDate = DateTime.UtcNow;
            var order = new Order
            {
                OrderDate = currentDate,
                UserId = userId,
                AddressId = dto.Address,
                AddressName = dto.AddressName,
                TotalItems = dto.Items.Length,
                TotalAmount = orderItems.Sum(x => x.Quantity * x.ProductPrice),
                OrderItems = orderItems
            };

            await UnitOfWork.Orders.AddAsync(order);

            return ApiResult.Success();
        }, "An error occurred while placing order.");
    }

    public async Task<ApiResult<OrderDto[]>> GetOrdersByUserIdAsync(Guid userId, int startIndex, int pageSize)
    {
        var orders = (await UnitOfWork.Orders.GetOrdersByUserIdAsync(userId))
            .OrderByDescending(x => x.Id)
            .Skip(startIndex)
            .Take(pageSize)
            .ToArray();

        return ApiResult<OrderDto[]>.Success(Mapper.Map<OrderDto[]>(orders));
    }

    public async Task<ApiResult<OrderDto>> GetOrderItemsByOrderIdAsync(long orderId, Guid userId)
    {
        var order = await UnitOfWork.Orders.GetByIdAsync(orderId);
        if (order is null) return ApiResult<OrderDto>.Failure("Order not found.");
        if (order.UserId != userId) return ApiResult<OrderDto>.Failure("Order not found.");
        return ApiResult<OrderDto>.Success(Mapper.Map<OrderDto>(order));
    }
}