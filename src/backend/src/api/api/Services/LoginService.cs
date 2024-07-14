using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using api.Dtos;
using api.Interface;
using api.Interface.Service;
using api.Models;
using api.Queries;
using api.Responses;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace api.Services;

public class LoginService : ILoginService
{
    private readonly ILoginRepository _loginRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public LoginService(ILoginRepository loginRepository, IMapper mapper, IConfiguration configuration)
    {
        _loginRepository = loginRepository;
        _mapper = mapper;
        _configuration = configuration;
    }
    
    public async Task<ApiResponse<LoginDto>> Login(LoginQuery loginQuery)
    {
        var response = new ApiResponse<LoginDto>();
        var usuario = await _loginRepository.GetByEmailAndPassword(loginQuery.Email, loginQuery.Password);
        if (usuario == null)
        {
            response.SetError("El email o contraseña incorrectos", HttpStatusCode.BadRequest);
            return response;
        }

        var token = GenerateToken(usuario);

        var login = new LoginDto()
        {
            Email = usuario.Email,
            Password = usuario.Password,
            Token = token
        };

        response.Data = _mapper.Map<LoginDto>(login);
        return response;

    }

    private string GenerateToken(usuario usu)
    {
        var claim = new[]
        {
            new Claim(ClaimTypes.Email, usu.Email),
            new Claim("Password", usu.Password),
            new Claim(ClaimTypes.Role, usu.IdRolNavigation.Nombre)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var securityToken = new JwtSecurityToken(
            claims: claim,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: credentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return token;
    }
}