using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuariosNegocio _negocio;

    public UsuariosController(IUsuariosNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(Usuarios entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(Usuarios entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(Usuarios entidad) => Ok(_negocio.Borrar(entidad));
}