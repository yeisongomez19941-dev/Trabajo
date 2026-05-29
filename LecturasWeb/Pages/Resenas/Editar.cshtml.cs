using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entidades = Libreria_Lecturas.Entidades;

namespace LecturasWeb.Pages.Resenas
{
    public class EditarModel : PageModel
    {
        private readonly IResenasNegocio _negocio;
        private readonly IUsuariosNegocio _usuariosNegocio;
        private readonly ILibrosNegocio _librosNegocio;

        public EditarModel(
            IResenasNegocio negocio,
            IUsuariosNegocio usuariosNegocio,
            ILibrosNegocio librosNegocio)
        {
            _negocio = negocio;
            _usuariosNegocio = usuariosNegocio;
            _librosNegocio = librosNegocio;
        }

        [BindProperty]
        public Entidades.Resenas Resenas { get; set; } = new();

        public List<Entidades.Usuarios> Usuarios { get; set; } = new();
        public List<Entidades.Libros> Libros { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var resena = _negocio.Consultar().FirstOrDefault(r => r.Id == id);

            if (resena == null)
                return RedirectToPage("/Resenas/Index");

            Resenas = resena;
            CargarListas();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CargarListas();
                return Page();
            }

            _negocio.Modificar(Resenas);
            return RedirectToPage("/Resenas/Index");
        }

        private void CargarListas()
        {
            Usuarios = _usuariosNegocio.Consultar();
            Libros = _librosNegocio.Consultar();
        }
    }
}