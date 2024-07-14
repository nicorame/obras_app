using System.Net;
using api.Dtos;
using api.Interface;
using api.Interface.Service;
using api.Models;
using api.Queries;
using api.Responses;
using AutoMapper;

namespace api.Services;

public class ServiceUno : IServiceUno
{
    private readonly IRepositoryUno _repositoryUno;
    private readonly IMapper _mapper;
    public ServiceUno(IRepositoryUno repositoryUno, IMapper mapper)
    {
        _repositoryUno = repositoryUno;
        _mapper = mapper;
    }
    public async Task<ApiResponse<List<SociosDto>>> GetAll()
    {
        var response = new ApiResponse<List<SociosDto>>();
        var socios = await _repositoryUno.GetAllSocios();
        if (socios != null && socios.Count > 0)
        {
            response.Data = _mapper.Map<List<SociosDto>>(socios);
            return response;
        }
        else
        {
            response.SetError("No hay socios en la base de datos", HttpStatusCode.BadRequest);
            return response;
        }
    }

    public async Task<ApiResponse<SociosDto>> GetById(Guid id)
    {
        var response = new ApiResponse<SociosDto>();
        var socio = await _repositoryUno.GetById(id);
        if (socio != null)
        {
            response.Data = _mapper.Map<SociosDto>(socio);
            return response;
        }
        else
        {
            response.SetError("El usuario con id: " + id +" no existe", HttpStatusCode.BadRequest);
            return response;
        }
    }

    public async Task<ApiResponse<SociosDto>> PostSocio(NuevoSocioQuery nuevoSocioQuery)
    {
        var response = new ApiResponse<SociosDto>();
        var deporte = await _repositoryUno.GetDeporteById(nuevoSocioQuery.IdDeporte);
        if (deporte == null)
        {
            response.SetError("No existe el deporte", HttpStatusCode.BadRequest);
        }

        var nuevoSocio = new socio()
        {
            Id = Guid.NewGuid(),
            Email = nuevoSocioQuery.Email,
            Activo = true,
            Nombre = nuevoSocioQuery.Nombre,
            Apellido = nuevoSocioQuery.Apellido,
            Dni = nuevoSocioQuery.Dni,
            Telefono = nuevoSocioQuery.Telefono,
            Calle = nuevoSocioQuery.Calle,
            Numero = nuevoSocioQuery.Numero,
            CodPost = nuevoSocioQuery.CodPost,
            Provincia = nuevoSocioQuery.Provincia,
            Ciudad = nuevoSocioQuery.Ciudad,
            FechaAlta = DateOnly.FromDateTime(DateTime.Now),
            IdDeporteNavigation = deporte
        };

        nuevoSocio = await _repositoryUno.PostSocio(nuevoSocio);
        response.Data = _mapper.Map<SociosDto>(nuevoSocio);
        return response;
    }
}