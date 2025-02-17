using AutoMapper;
using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Api.Interfaces.Persistence;
using FreshVegCart.Api.Interfaces.Services;
using FreshVegCart.Shared.Dtos;
using FreshVegCart.Shared.RecordResults;

namespace FreshVegCart.Api.Services;

public class UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger) : BaseService<UserService>(unitOfWork, mapper, logger), IUserService
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