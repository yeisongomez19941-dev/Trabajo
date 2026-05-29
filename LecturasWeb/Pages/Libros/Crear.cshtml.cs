using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Libros
{
    public class CrearModel : PageModel
    {
        private readonly ILibrosNegocio _negocio;
        private readonly IGenerosNegocio _negocioGeneros;

        public CrearModel(ILibrosNegocio negocio, IGenerosNegocio negocioGeneros)
        {
            _negocio = negocio;
            _negocioGeneros = negocioGeneros;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Libros Libro { get; set; } = new();

        public List<Libreria_Lecturas.Entidades.Generos> ListaGeneros { get; set; } = new();

        public void OnGet()
        {
            ListaGeneros = _negocioGeneros.Consultar();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Libro);
            return RedirectToPage("/Libros");
        }
    }
}