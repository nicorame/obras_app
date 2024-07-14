using api.Interface.Service;
using api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class LoginController : Controller
{
    private readonly ILoginService _service;

    public LoginController(ILoginService service)
    {
        _service = service;
    }

    [HttpPost("login/post")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query)
    {
        var response = await _service.Login(query);
        return Ok(response);
    } 
}