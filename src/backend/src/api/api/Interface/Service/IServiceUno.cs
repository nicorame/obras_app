using api.Dtos;
using api.Queries;
using api.Responses;

namespace api.Interface.Service;

public interface IServiceUno
{
    Task<ApiResponse<List<SociosDto>>> GetAll();
    Task<ApiResponse<SociosDto>> GetById(Guid id);
    Task<ApiResponse<SociosDto>> PostSocio(NuevoSocioQuery nuevoSocioQuery);
    Task<ApiResponse<List<DeportesDto>>> GetAllDeportes();
}