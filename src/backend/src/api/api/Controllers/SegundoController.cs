using api.Interface.Service;
using api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class SegundoController : Controller
{
    private readonly IServiceDos _serviceDos;

    public SegundoController(IServiceDos serviceDos)
    {
        _serviceDos = serviceDos;
    }

    [HttpGet("/segundo/GetObras")]
    public async Task<IActionResult> GetObras()
    {
        var response = await _serviceDos.GetObras();
        return Ok(response);
    }

    [HttpGet("/segundo/GetAlbaniles/{idObra}")]
    public async Task<IActionResult> GetAlbaniles(Guid idObra)
    {
        var response = await _serviceDos.GetAlbaniles(idObra);
        return Ok(response);
    }

    [HttpPost("/segundo/PostAlbanilXObra")]
    public async Task<IActionResult> PostAlbanilXObra([FromBody] NuevoAlbanilXObraQuery query)
    {
        var response = await _serviceDos.PostAlbanilXObra(query);
        return Ok(response);
    }

    [HttpPost("/segundo/PostAlbanil")]
    public async Task<IActionResult> PostAlbanil([FromBody] NuevoAlbanilQuery query)
    {
        var response = await _serviceDos.PostAlbanil(query);
        return Ok(response);
    }
}