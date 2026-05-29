using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class EstadoLecturasController : ControllerBase
{
    private readonly IEstadoLecturasNegocio _negocio;

    public EstadoLecturasController(IEstadoLecturasNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(EstadoLecturas entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(EstadoLecturas entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(EstadoLecturas entidad) => Ok(_negocio.Borrar(entidad));
}