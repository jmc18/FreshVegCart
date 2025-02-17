using FreshVegCart.Shared.Dtos;
using FreshVegCart.Shared.RecordResults;

namespace FreshVegCart.Api.Interfaces.Services;

public interface IUserService
{
    Task<ApiResult> SaveAddressAsync(AddressDto dto, Guid userId);
    Task<ApiResult<AddressDto[]>> GetAddressesByUserIdAsync(Guid userId, bool isActive = true);
}