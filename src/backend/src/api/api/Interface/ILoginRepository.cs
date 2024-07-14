using api.Models;

namespace api.Interface;

public interface ILoginRepository
{
    Task<usuario> GetByEmailAndPassword(string email, string password);
}