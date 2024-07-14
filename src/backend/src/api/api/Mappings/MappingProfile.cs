using api.Dtos;
using api.Models;
using AutoMapper;

namespace api.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<socio, SociosDto>();
        CreateMap<deporte, DeportesDto>();
    }
}