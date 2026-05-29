using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class RecomendacionesController : ControllerBase
{
    private readonly IRecomendacionesNegocio _negocio;

    public RecomendacionesController(IRecomendacionesNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(Recomendaciones entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(Recomendaciones entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(Recomendaciones entidad) => Ok(_negocio.Borrar(entidad));
}