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
        CreateMap<obra, ObrasDto>();
        CreateMap<tipos_obra, TipoObraDto>();
        CreateMap<albanile, AlbanilesDto>();
        CreateMap<albaniles_x_obra, AlbanilesXObra>();
    }
}