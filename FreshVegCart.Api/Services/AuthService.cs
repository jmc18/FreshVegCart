using AutoMapper;
using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence;
using FreshVegCart.Api.Interfaces.Services;
using FreshVegCart.Shared.Dtos;
using FreshVegCart.Shared.RecordResults;
using Microsoft.AspNetCore.Identity;

namespace FreshVegCart.Api.Services;

public class AuthService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<User> passwordHasher, ILogger<AuthService> logger) : BaseService<AuthService>(unitOfWork, mapper, logger), IAuthService
{
    public async Task<ApiResult> RegisterAsync(RegisterDto dto)
    {
        return await ExecuteAsync(async () =>
        {
            var user = Mapper.Map<User>(dto);
            user.PasswordHash = passwordHasher.HashPassword(user, dto.Password);
            await UnitOfWork.Users.AddAsync(user);
            Logger.LogInformation("User {Email} registered successfully.", user.Email);
            return ApiResult.Success();
        }, "An error occurred while registering user.");
    }

    public async Task<ApiResult<LoggedInUser>> LoginAsync(LoginDto dto)
    {
        return await ExecuteAsync(async () =>
        {
            var user = await UnitOfWork.Users.GetByEmailAsync(dto.Username);
            if (user is null)
            {
                return ApiResult<LoggedInUser>.Failure("User does not exist.");
            }

            var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, dto.Password);
            if (verificationResult != PasswordVerificationResult.Success)
            {
                return ApiResult<LoggedInUser>.Failure("Incorrect password.");
            }

            var loggedInUser = Mapper.Map<LoggedInUser>(user);
            return ApiResult<LoggedInUser>.Success(loggedInUser with { Token = "token" });
        }, "An error occurred while logging in user.");
    }

    public async Task<ApiResult> ChangePasswordAsync(ChangePasswordDto dto, Guid userId)
    {
        return await ExecuteAsync(async () =>
        {
            var user = await UnitOfWork.Users.GetByIdAsync(userId);
            if (user is null) return ApiResult.Failure("User not found.");
            var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, dto.OldPassword);
            if (verificationResult != PasswordVerificationResult.Success) return ApiResult.Failure("Incorrect password.");
            user.PasswordHash = passwordHasher.HashPassword(user, dto.NewPassword);
            await UnitOfWork.Users.UpdateAsync(user);
            return ApiResult.Success();
        }, "An error occurred while changing password.");
    }
}