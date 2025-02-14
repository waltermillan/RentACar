using AutoMapper;
using Core.Entities;

namespace API.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Configuración de mapeo entre Car y CarWithPrice
        CreateMap<Car, CarWithPrice>()
            .ForMember(dest => dest.Car, opt => opt.MapFrom(src => src));

        // Si necesitas mapear entre Price y CarWithPrice, añade una configuración similar
        CreateMap<Price, CarWithPrice>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src));
    }
}
