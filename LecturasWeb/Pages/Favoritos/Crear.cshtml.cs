using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Favoritos
{
    public class CrearModel : PageModel
    {
        private readonly IFavoritosNegocio _negocio;

        public CrearModel(IFavoritosNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Favoritos Favoritos { get; set; } = new()
        {
            FechaMarcado = DateTime.Now
        };

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Favoritos);
            return RedirectToPage("/Favoritos");
        }
    }
}

