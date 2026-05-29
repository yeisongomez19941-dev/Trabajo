using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class LibrosController : ControllerBase
{
    private readonly ILibrosNegocio _negocio;

    public LibrosController(ILibrosNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(Libros entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(Libros entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(Libros entidad) => Ok(_negocio.Borrar(entidad));
}