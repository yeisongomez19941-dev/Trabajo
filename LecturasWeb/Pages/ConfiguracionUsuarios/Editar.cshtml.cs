using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.ConfiguracionUsuarios
{
    public class EditarModel : PageModel
    {
        private readonly IConfiguracionUsuariosNegocio _negocio;

        public EditarModel(IConfiguracionUsuariosNegocio negocio)
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
            if (!ModelState.IsValid) return Page();
            _negocio.Modificar(Configuracion);
            return RedirectToPage("/ConfiguracionUsuarios");
        }
    }
}