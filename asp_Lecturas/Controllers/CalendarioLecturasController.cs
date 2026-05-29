using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class CalendarioLecturasController : ControllerBase
{
    private readonly ICalendarioLecturasNegocio _negocio;

    public CalendarioLecturasController(ICalendarioLecturasNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(CalendarioLecturas entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(CalendarioLecturas entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(CalendarioLecturas entidad) => Ok(_negocio.Borrar(entidad));
}