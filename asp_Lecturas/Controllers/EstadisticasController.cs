using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class EstadisticasController : ControllerBase
{
    private readonly IEstadisticasNegocio _negocio;

    public EstadisticasController(IEstadisticasNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(Estadisticas entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(Estadisticas entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(Estadisticas entidad) => Ok(_negocio.Borrar(entidad));
}