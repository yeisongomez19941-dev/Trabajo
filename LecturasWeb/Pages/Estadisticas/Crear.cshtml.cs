using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Estadisticas
{

    public class CrearModel : PageModel
    {
        private readonly IEstadisticasNegocio _negocio;

        public CrearModel(IEstadisticasNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Estadisticas Estadisticas{ get; set; } = new();
        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Estadisticas);
            return RedirectToPage("/Estadisticas");
        }
    }
}



