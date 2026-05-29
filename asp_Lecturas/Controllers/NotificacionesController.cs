using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class NotificacionesController : ControllerBase
{
    private readonly INotificacionesNegocio _negocio;

    public NotificacionesController(INotificacionesNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(Notificaciones entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(Notificaciones entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(Notificaciones entidad) => Ok(_negocio.Borrar(entidad));
}