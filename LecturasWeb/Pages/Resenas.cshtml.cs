using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibreriaLecturas.Pages
{
    public class ResenasModel : PageModel
    {
        private readonly IResenasNegocio _resenasNegocio;
        private readonly IUsuariosNegocio _usuariosNegocio;
        private readonly ILibrosNegocio _librosNegocio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Conexion _context;
        public ResenasModel(
            IResenasNegocio resenasNegocio,
            IUsuariosNegocio usuariosNegocio,
            ILibrosNegocio librosNegocio,
            UserManager<IdentityUser> userManager,
            Conexion context)
        {
            _resenasNegocio = resenasNegocio;
            _usuariosNegocio = usuariosNegocio;
            _librosNegocio = librosNegocio;
            _userManager = userManager;
            _context = context;
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

        public async Task<IActionResult> OnPostGuardarAsync()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);

            if (usuarioDb == null) return RedirectToPage("/Account/Login");

            Cargar();

            if (Resena.Id == 0)
            {
                // Verificar si ya tiene reseña
                var existente = _resenasNegocio.Consultar()
                    .FirstOrDefault(r => r.UsuarioId == usuarioDb.Id);

                if (existente != null)
                {
                    Mensaje = "Ya dejaste una reseña.";
                    return Page();
                }

                Resena.UsuarioId = usuarioDb.Id;
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