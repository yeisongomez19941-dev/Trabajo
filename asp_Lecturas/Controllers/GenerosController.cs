using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class GenerosController : ControllerBase
{
    private readonly IGenerosNegocio _negocio;

    public GenerosController(IGenerosNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(Generos entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(Generos entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(Generos entidad) => Ok(_negocio.Borrar(entidad));
}