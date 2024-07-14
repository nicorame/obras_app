using api.Dtos;
using api.Queries;
using api.Responses;

namespace api.Interface.Service;

public interface IServiceDos
{
    Task<ApiResponse<List<ObrasDto>>> GetObras();
    Task<ApiResponse<List<AlbanilesDto>>> GetAlbaniles(Guid idObra);
    Task<ApiResponse<AlbanilesXObra>> PostAlbanilXObra(NuevoAlbanilXObraQuery nuevoAlbanilXObraQuery);
    Task<ApiResponse<AlbanilesDto>> PostAlbanil(NuevoAlbanilQuery nuevoAlbanilQuery);
}