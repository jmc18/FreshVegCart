using FreshVegCart.Api.Interfaces.Services;
using FreshVegCart.Shared.Dtos;
using FreshVegCart.Shared.RecordResults;
using Microsoft.AspNetCore.Mvc;

namespace FreshVegCart.Api.Endpoints;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var authGroup = endpoints.MapGroup("/api/auth").WithTags("Auth");

        authGroup.MapPost("/register", async ([FromBody] RegisterDto dto, [FromServices] IAuthService authService) =>
        { var response = await authService.RegisterAsync(dto);
            return TypedResults.Ok(response);
        }).Produces<ApiResult>().WithName("Register").WithTags("Auth");

        authGroup.MapPost("/login", async ([FromBody] LoginDto dto, [FromServices] IAuthService authService) =>
            {
                var response = await authService.LoginAsync(dto);
                return TypedResults.Ok(response);
            })
            .Produces<ApiResult<LoggedInUser>>()
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest).WithName("Login").WithTags("Auth");

        return endpoints;
    }
}