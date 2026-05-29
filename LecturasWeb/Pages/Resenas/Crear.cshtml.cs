using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Resenas
{
    public class CrearModel : PageModel
    {
        private readonly IResenasNegocio _negocio;
        private readonly IUsuariosNegocio _usuariosNegocio;
        private readonly ILibrosNegocio _librosNegocio;

        public CrearModel(
            IResenasNegocio negocio,
            IUsuariosNegocio usuariosNegocio,
            ILibrosNegocio librosNegocio)
        {
            _negocio = negocio;
            _usuariosNegocio = usuariosNegocio;
            _librosNegocio = librosNegocio;
        }

        [BindProperty]

        public Libreria_Lecturas.Entidades.Resenas Resenas { get; set; } = new();
        public List<Libreria_Lecturas.Entidades.Libros> Libros { get; set; } = new();
        public List<Libreria_Lecturas.Entidades.Usuarios> Usuarios { get; set; } = new();

        public void OnGet()
        {
            Usuarios = _usuariosNegocio.Consultar();
            Libros = _librosNegocio.Consultar();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Usuarios = _usuariosNegocio.Consultar();
                Libros = _librosNegocio.Consultar();
                return Page();
            }

            _negocio.Guardar(Resenas);
            return RedirectToPage("/Resenas/Index");
        }
    }
}