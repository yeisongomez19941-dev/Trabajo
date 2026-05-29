using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibreriaLecturas.Pages
{
    public class ResenasModel : PageModel
    {
        private readonly IResenasNegocio _resenasNegocio;
        private readonly IUsuariosNegocio _usuariosNegocio;
        private readonly ILibrosNegocio _librosNegocio;

        public ResenasModel(
            IResenasNegocio resenasNegocio,
            IUsuariosNegocio usuariosNegocio,
            ILibrosNegocio librosNegocio)
        {
            _resenasNegocio = resenasNegocio;
            _usuariosNegocio = usuariosNegocio;
            _librosNegocio = librosNegocio;
        }

        [BindProperty]
        public Resenas Resena { get; set; } = new();

        public List<Resenas> Resenas { get; set; } = new();
        public List<Usuarios> Usuarios { get; set; } = new();
        public List<Libros> Libros { get; set; } = new();
        public string Mensaje { get; set; } = string.Empty;

        public void OnGet()
        {
            Cargar();
        }

        public IActionResult OnPostGuardar()
        {
            Cargar();
            if (Resena.Id == 0)
            {
                _resenasNegocio.Guardar(Resena);
                Mensaje = "Reseña guardada correctamente.";
            }
            else
            {
                _resenasNegocio.Modificar(Resena);
                Mensaje = "Reseña actualizada correctamente.";
            }
            return RedirectToPage();
        }

        public IActionResult OnPostBorrar(int id)
        {
            var resena = _resenasNegocio.Consultar().FirstOrDefault(r => r.Id == id);
            if (resena != null)
            {
                _resenasNegocio.Borrar(resena);
                Mensaje = "Reseña eliminada.";
            }
            return RedirectToPage();
        }

        private void Cargar()
        {
            Resenas = _resenasNegocio.Consultar();
            Usuarios = _usuariosNegocio.Consultar();
            Libros = _librosNegocio.Consultar();
        }
    }
}