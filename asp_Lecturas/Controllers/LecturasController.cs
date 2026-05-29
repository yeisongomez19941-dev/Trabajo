using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class LecturasController : ControllerBase
{
    private readonly ILecturasNegocio _negocio;

    public LecturasController(ILecturasNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(Lecturas entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(Lecturas entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(Lecturas entidad) => Ok(_negocio.Borrar(entidad));
}