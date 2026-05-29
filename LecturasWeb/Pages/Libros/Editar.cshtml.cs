using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Libreria_Lecturas.Implementaciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Libros
{
    public class EditarModel : PageModel
    {
        private readonly ILibrosNegocio _negocio;
        private readonly IGenerosNegocio _negocioGeneros;
        private readonly Conexion _context;

        public EditarModel(ILibrosNegocio negocio, IGenerosNegocio negocioGeneros, Conexion context)
        {
            _negocio = negocio;
            _negocioGeneros = negocioGeneros;
            _context = context;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Libros Libro { get; set; } = new();
        public List<Libreria_Lecturas.Entidades.Generos> ListaGeneros { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Libro = _negocio.Consultar().FirstOrDefault(l => l.Id == id)!;
            if (Libro == null) return NotFound();
            ListaGeneros = _negocioGeneros.Consultar();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ListaGeneros = _negocioGeneros.Consultar();
                return Page();
            }
            _negocio.Modificar(Libro);
            AuditoriaHelper.Registrar(_context, "Libros", "Modificar", User.Identity?.Name ?? "sistema", $"Libro modificado: \"{Libro.Titulo}\"");
            return RedirectToPage("/Libros");
        }
    }
}