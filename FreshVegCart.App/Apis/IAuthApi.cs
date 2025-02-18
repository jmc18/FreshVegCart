using FreshVegCart.Shared.Dtos;
using FreshVegCart.Shared.RecordResults;
using Refit;

namespace FreshVegCart.App.Apis;

public interface IAuthApi
{
    [Post("api/auth/register")]
    Task<ApiResult> RegisterAsync(RegisterDto dto);

    [Post("api/auth/login")]
    Task<ApiResult<LoggedInUser>> LoginAsync(LoginDto dto);
}