using api.Dtos;
using api.Models;
using api.Queries;
using api.Responses;

namespace api.Interface.Service;

public interface ILoginService
{
    Task<ApiResponse<LoginDto>> Login(LoginQuery loginQuery);
}