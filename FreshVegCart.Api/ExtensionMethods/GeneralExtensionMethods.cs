using System.Security.Claims;

namespace FreshVegCart.Api.ExtensionMethods;

public static class GeneralExtensionMethods
{
    public static Guid? GetUserId(this ClaimsPrincipal user)
    {
        var result =  user.FindFirstValue(ClaimTypes.NameIdentifier);
        return result != null ? Guid.Parse(result) : null;
    }
}
