namespace FreshVegCart.Shared.Dtos;

public record LoggedInUser(Guid Id, string Name, string Email, string Token);