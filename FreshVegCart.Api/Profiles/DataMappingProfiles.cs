﻿using AutoMapper;
using FreshVegCart.Api.Data.Entities;
using FreshVegCart.Shared.Dtos;

namespace FreshVegCart.Api.Profiles;

public class DataMappingProfiles : Profile
{
    public DataMappingProfiles()
    {
        CreateMap<Product, ProductDto>().ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

        CreateMap<AddressDto, UserAddress>().ReverseMap();

        CreateMap<RegisterDto, User>()
            .ForMember(u => u.IsActive, opt => opt.MapFrom(_ => true));
        CreateMap<User, LoggedInUser>().ForMember(u => u.Token, opt => opt.Ignore());
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.OrderItems.Count))
            .ReverseMap();
    }
}
