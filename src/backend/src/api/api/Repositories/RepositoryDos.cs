using api.Data;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class RepositoryDos : IRepositoryDos
{
    private readonly ContextDb _contextDb;

    public RepositoryDos(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    public async Task<List<obra>> GetObras()
    {
        var obras = await _contextDb.obras
            .Include(o => o.IdTipoObraNavigation)
            .Include(o => o.albaniles_x_obras)
            .ToListAsync();
        return obras;
    }

    public async Task<albaniles_x_obra> GetAlbanilEnObra(Guid idAlbanil, Guid idObra)
    {
        var albanilEnOBra = await _contextDb.albaniles_x_obras
            .Include(a => a.IdAlbanilNavigation)
            .Include(a => a.IdObraNavigation)
            .Where(a => a.IdAlbanil == idAlbanil && a.IdObra == idObra)
            .FirstOrDefaultAsync();
        return albanilEnOBra;
    }

    public async Task<albanile> GetAlbanil(Guid id)
    {
        var albanil = await _contextDb.albaniles
            .FirstOrDefaultAsync(a => a.Id == id);
        return albanil;
    }
    
    public async Task<albaniles_x_obra> PostAlbanilXObra(albaniles_x_obra albanilesXObra)
    {
        await _contextDb.AddAsync(albanilesXObra);
        await _contextDb.SaveChangesAsync();
        return albanilesXObra;
    }

    public async Task<albanile> PostAlbanil(albanile albanile)
    {
        await _contextDb.AddAsync(albanile);
        await _contextDb.SaveChangesAsync();
        return albanile;
    }

    public async Task<List<albanile>> GetAlbaniles(Guid idObra)
    {
        var albanil = await _contextDb.albaniles_x_obras
            .Where(ao => ao.IdObra == idObra)
            .Select(ao => ao.IdAlbanil)
            .ToListAsync();

        var albanilesNoAsignados = await _contextDb.albaniles
            .Where(a => !albanil.Contains(a.Id))
            .ToListAsync();
        return albanilesNoAsignados;
    }
}