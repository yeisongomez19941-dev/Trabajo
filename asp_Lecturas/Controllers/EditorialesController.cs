using Microsoft.AspNetCore.Mvc;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

[ApiController]
[Route("[controller]/[action]")]
public class EditorialesController : ControllerBase
{
    private readonly IEditorialesNegocio _negocio;

    public EditorialesController(IEditorialesNegocio negocio)
    {
        _negocio = negocio;
    }

    [HttpGet] public IActionResult Consultar() => Ok(_negocio.Consultar());
    [HttpPost] public IActionResult Guardar(Editoriales entidad) => Ok(_negocio.Guardar(entidad));
    [HttpPut] public IActionResult Modificar(Editoriales entidad) => Ok(_negocio.Modificar(entidad));
    [HttpDelete] public IActionResult Borrar(Editoriales entidad) => Ok(_negocio.Borrar(entidad));
}