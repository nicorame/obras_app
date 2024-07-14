using api.Data;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class LoginRepository : ILoginRepository
{
    private readonly ContextDb _contextDb;

    public LoginRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<usuario> GetByEmailAndPassword(string email, string password)
    {
        var usuario = await _contextDb.usuarios
            .Include(u => u.IdRolNavigation)
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        return usuario;
    }
}