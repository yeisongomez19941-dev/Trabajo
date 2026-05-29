using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Favoritos
{
    public class EliminarModel : PageModel
    {
        private readonly IFavoritosNegocio _negocio;

        public EliminarModel(IFavoritosNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Favoritos Favoritos { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Favoritos = _negocio.Consultar().FirstOrDefault(c => c.Id == id)!;
            if (Favoritos == null) return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            _negocio.Borrar(Favoritos);
            return RedirectToPage("/Favoritos");
        }
    }

}
