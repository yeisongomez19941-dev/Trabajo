using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Logros
{
    public class EliminarModel : PageModel
    {
    private readonly ILogrosNegocio _negocio;

    public EliminarModel(ILogrosNegocio negocio)
    {
        _negocio = negocio;
    }

    [BindProperty]
    public Libreria_Lecturas.Entidades.Logros Logros { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        Logros = _negocio.Consultar().FirstOrDefault(l => l.Id == id)!;
        if (Logros == null) return NotFound();
        return Page();
    }

    public IActionResult OnPost()
    {
        _negocio.Borrar(Logros);
        return RedirectToPage("/Logros");
    }
}
}


    