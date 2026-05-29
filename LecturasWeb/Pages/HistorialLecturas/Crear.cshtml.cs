using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.HistorialLecturas
{
    public class CrearModel : PageModel
    {
     
            private readonly IHistorialLecturasNegocio _negocio;
            private readonly IEstadisticasNegocio _estadisticasNegocio;
            private readonly UserManager<IdentityUser> _userManager;
            private readonly Conexion _context;

            public CrearModel(
                IHistorialLecturasNegocio negocio,
                IEstadisticasNegocio estadisticasNegocio,
                UserManager<IdentityUser> userManager,
                Conexion context)
            {
                _negocio = negocio;
                _estadisticasNegocio = estadisticasNegocio;
                _userManager = userManager;
                _context = context;
            }

            [BindProperty]
            public Libreria_Lecturas.Entidades.HistorialLecturas Historial { get; set; } = new()
            {
                FechaInicio = DateTime.Now
            };

            public List<Libreria_Lecturas.Entidades.Libros> ListaLibros { get; set; } = new();

            public void OnGet()
            {
                ListaLibros = _context.Libros.ToList();
            }

            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid) return Page();

                var identityUser = await _userManager.GetUserAsync(User);
                var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);

                if (usuarioDb != null)
                {
                    Historial.UsuarioId = usuarioDb.Id;
                    _negocio.Guardar(Historial);

                    // Actualizar estadísticas automáticamente
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

                    var paginasTotales = totalHistorial
                        .Sum(h => h.PaginasLeidas ?? 0);

                    var promedio = librosLeidos > 0
                        ? (decimal)paginasTotales / librosLeidos
                        : 0;

                    if (estadistica == null)
                    {
                    _context.Estadisticas.Add(new Libreria_Lecturas.Entidades.Estadisticas
                    {
                        UsuarioId = usuarioDb.Id,
                        LibrosLeidos = librosLeidos,
                        PaginasTotales = paginasTotales,
                        PromedioPaginas = promedio
                    });
                }
                    else
                    {
                        estadistica.LibrosLeidos = librosLeidos;
                        estadistica.PaginasTotales = paginasTotales;
                        estadistica.PromedioPaginas = promedio;
                        _context.Estadisticas.Update(estadistica);
                    }

                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("/HistorialLecturas");
            }
    }
}




