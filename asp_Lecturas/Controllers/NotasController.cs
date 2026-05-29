using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class NotasController : ControllerBase
{
    private readonly INotasNegocio _negocio;

    public NotasController(INotasNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(Notas entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(Notas entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(Notas entidad) => Ok(_negocio.Borrar(entidad));
}