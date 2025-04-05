using AutoMapper;
using Core.Entities;

namespace API.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Configuration mapping beetwen Car and CarWithPrice
        CreateMap<Car, CarWithPrice>()
            .ForMember(dest => dest.Car, opt => opt.MapFrom(src => src));

        // Configuration mapping beetwen Price and CarWithPrice
        CreateMap<Price, CarWithPrice>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src));
    }
}
