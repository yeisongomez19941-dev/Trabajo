using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.HistorialLecturas
{
    public class EliminarModel : PageModel
    {
        private readonly IHistorialLecturasNegocio _negocio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Conexion _context;

        public EliminarModel(
            IHistorialLecturasNegocio negocio,
            UserManager<IdentityUser> userManager,
            Conexion context)
        {
            _negocio = negocio;
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.HistorialLecturas Historial { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Historial = _context.HistorialLecturas.FirstOrDefault(h => h.Id == id)!;
            if (Historial == null) return RedirectToPage("/HistorialLecturas");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);

            _negocio.Borrar(Historial);

            // Recalcular estadísticas tras eliminar
            if (usuarioDb != null)
            {
                var estadistica = _context.Estadisticas
                    .FirstOrDefault(e => e.UsuarioId == usuarioDb.Id);

                var totalHistorial = _context.HistorialLecturas
                    .Where(h => h.UsuarioId == usuarioDb.Id)
                    .ToList();

                var librosLeidos = totalHistorial
                    .Where(h => h.LibroId.HasValue)
                    .Select(h => h.LibroId)
                    .Distinct()
                    .Count();

                var paginasTotales = totalHistorial.Sum(h => h.PaginasLeidas ?? 0);
                var promedio = librosLeidos > 0 ? (decimal)paginasTotales / librosLeidos : 0;

                if (estadistica != null)
                {
                    estadistica.LibrosLeidos = librosLeidos;
                    estadistica.PaginasTotales = paginasTotales;
                    estadistica.PromedioPaginas = promedio;
                    _context.Estadisticas.Update(estadistica);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("/HistorialLecturas");
        }
    }
}