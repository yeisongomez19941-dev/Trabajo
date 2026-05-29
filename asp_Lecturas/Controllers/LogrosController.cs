using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class LogrosController : ControllerBase
{
    private readonly ILogrosNegocio _negocio;

    public LogrosController(ILogrosNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(Logros entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(Logros entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(Logros entidad) => Ok(_negocio.Borrar(entidad));
}