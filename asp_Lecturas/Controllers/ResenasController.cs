using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class ResenasController : ControllerBase
{
    private readonly IResenasNegocio _negocio;

    public ResenasController(IResenasNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(Resenas entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(Resenas entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(Resenas entidad) => Ok(_negocio.Borrar(entidad));
}