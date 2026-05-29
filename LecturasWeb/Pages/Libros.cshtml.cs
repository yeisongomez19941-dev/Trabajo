using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages
{
    public class LibrosModel : PageModel
    {
        private readonly ILibrosNegocio _negocio;

        public LibrosModel(ILibrosNegocio negocio)
        {
            _negocio = negocio;
        }

        public List<Libreria_Lecturas.Entidades.Libros> ListaLibros { get; set; } = new();

        public void OnGet()
        {
            ListaLibros = _negocio.Consultar();
        }
    }
}