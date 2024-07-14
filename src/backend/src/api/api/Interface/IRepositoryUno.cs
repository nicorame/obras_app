using api.Models;

namespace api.Interface;

public interface IRepositoryUno
{
    Task<socio> PostSocio(socio socio);
    Task<socio> GetById(Guid id);
    Task<List<socio>> GetAllSocios();
    Task<deporte> GetDeporteById(Guid id);
    Task<List<deporte>> GetAllDeportes();
}