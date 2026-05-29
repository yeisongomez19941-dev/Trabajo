using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
[ApiController]
[Route("[controller]/[action]")]
public class MetaLecturasController : ControllerBase
{
    private readonly IMetaLecturasNegocio _negocio;

    public MetaLecturasController(IMetaLecturasNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(MetaLecturas entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(MetaLecturas entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(MetaLecturas entidad) => Ok(_negocio.Borrar(entidad));
}