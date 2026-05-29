using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class ProgresoLecturasController : ControllerBase
{
    private readonly IProgresoLecturasNegocio _negocio;

    public ProgresoLecturasController(IProgresoLecturasNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(ProgresoLecturas entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(ProgresoLecturas entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(ProgresoLecturas entidad) => Ok(_negocio.Borrar(entidad));
}