using api.Data;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class RepositoryUno : IRepositoryUno
{
    private readonly ContextDb _contextDb;

    public RepositoryUno(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<socio> PostSocio(socio socio)
    {
        await _contextDb.AddAsync(socio);
        await _contextDb.SaveChangesAsync();
        return socio;
    }

    public async Task<socio> GetById(Guid id)
    {
        var socio = await _contextDb.socios
            .Include(s => s.IdDeporteNavigation)
            .Where(s => s.Activo == true)
            .FirstOrDefaultAsync(s => s.Id == id);
        return socio;
    }

    public async Task<List<socio>> GetAllSocios()
    {
        var socios = await _contextDb.socios
            .Include(s => s.IdDeporteNavigation)
            .Where(s => s.Activo == true)
            .ToListAsync();
        return socios;
    }

    public async Task<deporte> GetDeporteById(Guid id)
    {
        var deporte = await _contextDb.deportes
            .FirstOrDefaultAsync(d => d.Id == id);
        return deporte;
    }

    public async Task<List<deporte>> GetAllDeportes()
    {
        var deportes = await _contextDb.deportes.ToListAsync();
        return deportes;
    }
}