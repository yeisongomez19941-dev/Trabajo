using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class ConfiguracionUsuariosController : ControllerBase
{
    private readonly IConfiguracionUsuariosNegocio _negocio;

    public ConfiguracionUsuariosController(IConfiguracionUsuariosNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(ConfiguracionUsuarios entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(ConfiguracionUsuarios entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(ConfiguracionUsuarios entidad) => Ok(_negocio.Borrar(entidad));
}