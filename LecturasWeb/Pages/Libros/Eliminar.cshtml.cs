using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Libros
{
    public class EliminarModel : PageModel
    {
        private readonly ILibrosNegocio _negocio;

        public EliminarModel(ILibrosNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Libros Libro { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Libro = _negocio.Consultar().FirstOrDefault(l => l.Id == id)!;
            if (Libro == null) return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            _negocio.Borrar(Libro);
            return RedirectToPage("/Libros");
        }
    }
}