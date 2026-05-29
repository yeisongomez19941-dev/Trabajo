using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class HistorialLecturasController : ControllerBase
{
    private readonly IHistorialLecturasNegocio _negocio;

    public HistorialLecturasController(IHistorialLecturasNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(HistorialLecturas entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(HistorialLecturas entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(HistorialLecturas entidad) => Ok(_negocio.Borrar(entidad));
}