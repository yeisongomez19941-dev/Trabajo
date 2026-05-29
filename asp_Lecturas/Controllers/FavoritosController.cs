using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class FavoritosController : ControllerBase
{
    private readonly IFavoritosNegocio _negocio;

    public FavoritosController(IFavoritosNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(Favoritos entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(Favoritos entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(Favoritos entidad) => Ok(_negocio.Borrar(entidad));
}