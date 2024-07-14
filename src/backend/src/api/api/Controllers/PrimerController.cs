using api.Interface.Service;
using api.Queries;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class PrimerController : Controller
{
    private readonly IServiceUno _serviceUno;

    public PrimerController(IServiceUno serviceUno)
    {
        _serviceUno = serviceUno;
    }

    [HttpGet("/primer/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _serviceUno.GetAll();
        return Ok(response);
    }
    
    [HttpGet("/primer/deportes/GetAll")]
    public async Task<IActionResult> GetAllDeportes()
    {
        var response = await _serviceUno.GetAllDeportes();
        return Ok(response);
    }

    [HttpGet("/primer/GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _serviceUno.GetById(id);
        return Ok(response);
    }

    [HttpPost("/primer/PostSocio")]
    public async Task<IActionResult> PostSocio([FromBody] NuevoSocioQuery query)
    {
        var response = await _serviceUno.PostSocio(query);
        return Ok(response);
    }
}