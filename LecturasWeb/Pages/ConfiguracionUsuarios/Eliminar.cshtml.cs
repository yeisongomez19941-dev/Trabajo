using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.ConfiguracionUsuarios
{
    public class EliminarModel : PageModel
    {
        private readonly IConfiguracionUsuariosNegocio _negocio;

        public EliminarModel(IConfiguracionUsuariosNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.ConfiguracionUsuarios Configuracion { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Configuracion = _negocio.Consultar().FirstOrDefault(c => c.Id == id)!;
            if (Configuracion == null) return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            _negocio.Borrar(Configuracion);
            return RedirectToPage("/ConfiguracionUsuarios");
        }
    }
}