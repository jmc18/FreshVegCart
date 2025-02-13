using AutoMapper;
using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence;
using FreshVegCart.Shared.Dtos;
using Microsoft.AspNetCore.Identity;

namespace FreshVegCart.Api.Services;

public class ProductService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductService> logger) : BaseService<ProductService>(unitOfWork, mapper, logger)
{
    public async Task<ProductDto[]> GetProductsAsync()
    {
        return await ExecuteAsync(async () =>
        {
            var products = await _unitOfWork.Products.GetProductsByStatusAsync(true);
            return _mapper.Map<ProductDto[]>(products);
        }, "An error occurred while retrieving products.");
    }
}

public class AuthService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<User> passwordHasher, ILogger<AuthService> logger) : BaseService<AuthService>(unitOfWork, mapper, logger)
{
    public async Task<ApiResult> RegisterAsync(RegisterDto dto)
    {
        return await ExecuteAsync(async () =>
        {
            var user = _mapper.Map<User>(dto);
            user.PasswordHash = passwordHasher.HashPassword(user, dto.Password);
            await _unitOfWork.Users.AddAsync(user);
            _logger.LogInformation("User {Email} registered successfully.", user.Email);
            return ApiResult.Success();
        }, "An error occurred while registering user.");
    }

    public async Task<ApiResult<LoggedInUser>> LoginAsync(LoginDto dto)
    {
        return await ExecuteAsync(async () =>
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(dto.Username);
            if (user is null)
            {
                return ApiResult<LoggedInUser>.Failure("User does not exist.");
            }

            var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, dto.Password);
            if (verificationResult != PasswordVerificationResult.Success)
            {
                return ApiResult<LoggedInUser>.Failure("Incorrect password.");
            }

            var loggedInUser = _mapper.Map<LoggedInUser>(user);
            return ApiResult<LoggedInUser>.Success(loggedInUser with { Token = "token" });
        }, "An error occurred while logging in user.");
    }
}

public class UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger) : BaseService<UserService>(unitOfWork, mapper, logger)
{
    public async Task<ApiResult> SaveAddressAsync(AddressDto dto, Guid userId)
    {
        return await ExecuteAsync(async () =>
        {
            if (dto.IsDefault)
            {
                await _unitOfWork.UserAddresses.UnsetDefaultAddress(userId);
            }
            if (dto.Id != null)
            {
                var userAddress = await _unitOfWork.UserAddresses.GetByIdAsync((Guid)dto.Id);
                if (userAddress is null) return ApiResult.Failure("Address not found.");
                await _unitOfWork.UserAddresses.UpdateAsync(mapper.Map(dto, userAddress));
            }
            else
            {
                var address = _mapper.Map<UserAddress>(dto);
                address.UserId = userId;
                await _unitOfWork.UserAddresses.AddAsync(address);
            }
                
            return ApiResult.Success();
        }, "An error occurred while saving address.");
    }

    public async Task<ApiResult<AddressDto[]>> GetAddressesByUserIdAsync(Guid userId, bool isActive = true)
    {
        return await ExecuteAsync(async () =>
        {
            var addresses = _mapper.Map<AddressDto[]>(await _unitOfWork.UserAddresses.GetUserAddressesAsync(userId, isActive));
            return ApiResult<AddressDto[]>.Success(addresses);
        }, "An error occurred while retrieving addresses.");
    }
}
