using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class AutoresController : ControllerBase
{
    private readonly IAutoresNegocio _negocio;

    public AutoresController(IAutoresNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(Autores entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(Autores entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(Autores entidad) => Ok(_negocio.Borrar(entidad));
}