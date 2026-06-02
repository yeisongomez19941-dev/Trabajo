using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Favoritos
{
    public class EliminarModel : PageModel
    {
        private readonly IFavoritosNegocio _negocio;
        private readonly IAuditoriasNegocio _auditorias;

        public EliminarModel(IFavoritosNegocio negocio, IAuditoriasNegocio auditorias)
        {
            _negocio = negocio;
            _auditorias = auditorias;
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
            _auditorias.Registrar("Favoritos", "Eliminar",
                User.Identity?.Name ?? "Sistema",
                $"Favorito eliminado: {Favoritos.Id}");
            return RedirectToPage("/Favoritos");
        }
    }

}
