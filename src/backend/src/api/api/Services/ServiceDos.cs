using System.Net;
using api.Dtos;
using api.Interface;
using api.Interface.Service;
using api.Models;
using api.Queries;
using api.Responses;
using AutoMapper;

namespace api.Services;

public class ServiceDos : IServiceDos
{
    private readonly IRepositoryDos _repositoryDos;
    private readonly IMapper _mapper;

    public ServiceDos(IRepositoryDos repositoryDos, IMapper mapper)
    {
        _repositoryDos = repositoryDos;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<List<ObrasDto>>> GetObras()
    {
        var response = new ApiResponse<List<ObrasDto>>();
        var obras = await _repositoryDos.GetObras();
        if (obras != null && obras.Count > 0)
        {
            var obrasDto = obras.Select(o => new ObrasDto()
            {
                Id = o.Id,
                Nombre = o.Nombre,
                DatosVarios = o.DatosVarios,
                IdTipoObraNavigation = new TipoObraDto()
                {
                    Nombre = o.IdTipoObraNavigation.Nombre
                },
                CantidadAlbaniles = o.albaniles_x_obras.Count
            }).ToList();
            response.Data = obrasDto;
            return response;
        }
        else
        {
            response.SetError("No existen registros de obras", HttpStatusCode.BadRequest);
            return response;
        }
    }

    public async Task<ApiResponse<List<AlbanilesDto>>> GetAlbaniles(Guid idObra)
    {
        var response = new ApiResponse<List<AlbanilesDto>>();
        var albaniles = await _repositoryDos.GetAlbaniles(idObra);
        if (albaniles != null && albaniles.Count > 0)
        {
            response.Data = _mapper.Map<List<AlbanilesDto>>(albaniles);
            return response;
        }
        else
        {
            response.SetError("No existen albaniles NO asignados a una obra", HttpStatusCode.NotFound);
            return response;
        }
    }

    public async Task<ApiResponse<AlbanilesXObra>> PostAlbanilXObra(NuevoAlbanilXObraQuery nuevoAlbanilXObraQuery)
    {
        var response = new ApiResponse<AlbanilesXObra>();
        var albanilRegistrado =
            await _repositoryDos.GetAlbanilEnObra(nuevoAlbanilXObraQuery.IdAlbanil, nuevoAlbanilXObraQuery.IdObra);
        if (albanilRegistrado != null)
        {
            response.SetError("El albanil ya esta registrado en la obra", HttpStatusCode.BadRequest);
            return response;
        }

        var nuevoAlbanilXObra = new albaniles_x_obra()
        {
            Id = Guid.NewGuid(),
            IdAlbanil = nuevoAlbanilXObraQuery.IdAlbanil,
            IdObra = nuevoAlbanilXObraQuery.IdObra,
            TareaARealizar = nuevoAlbanilXObraQuery.TareaARealizar,
            FechaAlta = DateOnly.FromDateTime(DateTime.Now)
        };

        nuevoAlbanilXObra = await _repositoryDos.PostAlbanilXObra(nuevoAlbanilXObra);
        response.Data = _mapper.Map<AlbanilesXObra>(nuevoAlbanilXObra);
        return response;

    }

    public async Task<ApiResponse<AlbanilesDto>> PostAlbanil(NuevoAlbanilQuery nuevoAlbanilQuery)
    {
        var response = new ApiResponse<AlbanilesDto>();
        var nuevoAlbanil = new albanile()
        {
            Id = Guid.NewGuid(),
            Nombre = nuevoAlbanilQuery.Nombre,
            Apellido = nuevoAlbanilQuery.Apellido,
            Dni = nuevoAlbanilQuery.Dni,
            Telefono = nuevoAlbanilQuery.Telefono,
            Calle = nuevoAlbanilQuery.Calle,
            Numero = nuevoAlbanilQuery.Numero,
            CodPost = nuevoAlbanilQuery.CodPost,
            Activo = true,
            FechaAlta = DateOnly.FromDateTime(DateTime.Now)
        };

        nuevoAlbanil = await _repositoryDos.PostAlbanil(nuevoAlbanil);
        response.Data = _mapper.Map<AlbanilesDto>(nuevoAlbanil);
        return response;
    }
}