using api.Models;

namespace api.Interface;

public interface IRepositoryDos
{
    Task<List<obra>> GetObras();
    Task<albaniles_x_obra> GetAlbanilEnObra(Guid idAlbanil, Guid idObra); 
    Task<albaniles_x_obra> PostAlbanilXObra(albaniles_x_obra albanilesXObra);
    Task<albanile> PostAlbanil(albanile albanile);
    Task<List<albanile>> GetAlbaniles(Guid idObra);
}