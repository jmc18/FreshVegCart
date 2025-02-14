using FreshVegCart.Shared.Dtos;

namespace FreshVegCart.Shared.RecordResults;

public record PlaceOrderDto(Guid UserAddressId, OrderItemSaveDto[] Items);
