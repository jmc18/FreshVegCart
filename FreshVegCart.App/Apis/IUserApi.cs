using FreshVegCart.Shared.Dtos;
using FreshVegCart.Shared.RecordResults;
using Refit;

namespace FreshVegCart.App.Apis;

[Headers("Authorization: Bearer ")]
public interface IUserApi
{
    [Post("api/users/addresses")]
    Task<ApiResult> SaveAddressAsync(AddressDto dto, Guid userId);
    [Get("api/users/addresses")]
    Task<ApiResult<AddressDto[]>> GetAddressesByUserIdAsync(Guid userId, bool isActive = true);
    [Put("api/users/change-password")]
    Task<ApiResult> ChangePasswordAsync(ChangePasswordDto dto, Guid userId);
}