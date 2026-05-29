using Libreria_Lecturas.Interfaces;
using Libreria_Lecturas.Implementaciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Libros
{
    public class EliminarModel : PageModel
    {
        private readonly ILibrosNegocio _negocio;
        private readonly Conexion _context;

        public EliminarModel(ILibrosNegocio negocio, Conexion context)
        {
            _negocio = negocio;
            _context = context;
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
            AuditoriaHelper.Registrar(_context, "Libros", "Eliminar", User.Identity?.Name ?? "sistema", $"Libro eliminado: \"{Libro.Titulo}\"");
            _negocio.Borrar(Libro);
            return RedirectToPage("/Libros");
        }
    }
}