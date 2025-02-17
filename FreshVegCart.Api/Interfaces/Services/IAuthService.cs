using FreshVegCart.Shared.Dtos;
using FreshVegCart.Shared.RecordResults;

namespace FreshVegCart.Api.Interfaces.Services;

public interface IAuthService
{
    Task<ApiResult> RegisterAsync(RegisterDto dto);
    Task<ApiResult<LoggedInUser>> LoginAsync(LoginDto dto);
    Task<ApiResult> ChangePasswordAsync(ChangePasswordDto dto, Guid userId);
}