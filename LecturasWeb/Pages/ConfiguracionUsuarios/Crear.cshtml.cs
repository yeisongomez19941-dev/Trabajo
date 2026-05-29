using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.ConfiguracionUsuarios
{
    public class CrearModel : PageModel
    {
        private readonly IConfiguracionUsuariosNegocio _negocio;

        public CrearModel(IConfiguracionUsuariosNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.ConfiguracionUsuarios Configuracion { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Configuracion);
            return RedirectToPage("/ConfiguracionUsuarios");
        }
    }
}