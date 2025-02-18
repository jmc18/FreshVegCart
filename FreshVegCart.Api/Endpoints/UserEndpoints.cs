using System.Security.Claims;
using FreshVegCart.Api.ExtensionMethods;
using FreshVegCart.Api.Interfaces.Services;
using FreshVegCart.Shared.Dtos;
using FreshVegCart.Shared.RecordResults;
using Microsoft.AspNetCore.Mvc;

namespace FreshVegCart.Api.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var userGroup = endpoints.MapGroup("/api/users")
            .RequireAuthorization()
            .WithTags("Users");

        userGroup.MapPost("/addresses", async ([FromBody] AddressDto dto, [FromServices] IUserService userService, [FromServices] ClaimsPrincipal principal) 
                => Results.Ok(await userService.SaveAddressAsync(dto, (Guid)principal.GetUserId())))
            .Produces<ApiResult>()
            .WithName("SaveAddress");

        userGroup.MapGet("/addresses", async ([FromServices] IUserService userService, [FromServices] ClaimsPrincipal principal)
                => Results.Ok(await userService.GetAddressesByUserIdAsync((Guid)principal.GetUserId())))
            .Produces<AddressDto[]>()
            .WithName("GetAddress");

        userGroup.MapPut("/change-password", async ([FromBody] ChangePasswordDto dto, [FromServices] IAuthService authService, [FromServices] ClaimsPrincipal principal)
                => Results.Ok(await authService.ChangePasswordAsync(dto, (Guid)principal.GetUserId())))
            .Produces<ApiResult>()
            .WithName("ChangePassword");

        return endpoints;
    }
}