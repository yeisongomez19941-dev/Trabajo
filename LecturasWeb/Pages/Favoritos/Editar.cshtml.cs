using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Favoritos
{
    public class EditarModel : PageModel
    {
        private readonly IFavoritosNegocio _negocio;

        public EditarModel(IFavoritosNegocio negocio)
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
            if (!ModelState.IsValid) return Page();
            _negocio.Modificar(Favoritos);
            return RedirectToPage("/Favoritos");
        }
    }
}
