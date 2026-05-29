using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Logros
{
    public class CrearModel : PageModel
    {
        private readonly ILogrosNegocio _negocio;

        public CrearModel(ILogrosNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Logros Logros { get; set; } = new();
        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Logros);
            return RedirectToPage("/Logros");
        }
    }
}
