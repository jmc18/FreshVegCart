using AutoMapper;
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
    }
}
