using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages
{
    public class NotasModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Conexion _context;
        private readonly INotasNegocio _notasNegocio;

        public NotasModel(UserManager<IdentityUser> userManager, Conexion context, INotasNegocio notasNegocio)
        {
            _userManager = userManager;
            _context = context;
            _notasNegocio = notasNegocio;
        }

        public List<Libreria_Lecturas.Entidades.Notas> MisNotas { get; set; } = new();
        public List<Libreria_Lecturas.Entidades.Libros> Libros { get; set; } = new();
        [BindProperty] public int Pagina { get; set; }
        [BindProperty] public string? Contenido { get; set; }
        [BindProperty] public int LibroId { get; set; }
        [BindProperty] public int NotaIdBorrar { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity!.IsAuthenticated)
                return RedirectToPage("/Account/Login");

            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);
            if (usuarioDb == null) return RedirectToPage("/Account/Login");

            MisNotas = _notasNegocio.Consultar(usuarioDb.Id);
            Libros = _context.Libros.ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostGuardarAsync()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);
            if (usuarioDb == null) return RedirectToPage("/Account/Login");

            var nota = new Libreria_Lecturas.Entidades.Notas
            {
                Pagina = Pagina,
                Contenido = Contenido,
                LibroId = LibroId,
                UsuarioId = usuarioDb.Id,
                Fecha = DateTime.Now
            };
            _notasNegocio.Guardar(nota);
            return RedirectToPage();
        }

        public IActionResult OnPostBorrarAsync()
        {
            var nota = _context.Notas.Find(NotaIdBorrar);
            if (nota != null) _notasNegocio.Borrar(nota);
            return RedirectToPage();
        }
    }
}