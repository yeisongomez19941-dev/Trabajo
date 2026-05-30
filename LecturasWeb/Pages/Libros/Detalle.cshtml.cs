using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace LecturasWeb.Pages.Libros
{
    public class DetalleModel : PageModel
    {
        private readonly ILibrosNegocio _negocio;
        private readonly ILecturasNegocio _lecturasNegocio;
        private readonly IProgresoLecturasNegocio _progresoNegocio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Conexion _context;

        public DetalleModel(
            ILibrosNegocio negocio,
            ILecturasNegocio lecturasNegocio,
            IProgresoLecturasNegocio progresoNegocio,
            UserManager<IdentityUser> userManager,
            Conexion context)
        {
            _negocio = negocio;
            _lecturasNegocio = lecturasNegocio;
            _progresoNegocio = progresoNegocio;
            _userManager = userManager;
            _context = context;
        }

        public Libreria_Lecturas.Entidades.Libros Libro { get; set; } = new();
        public Libreria_Lecturas.Entidades.HistorialLecturas? HistorialActual { get; set; }
        public Libreria_Lecturas.Entidades.Lecturas? LecturaActual { get; set; }
        public List<Libreria_Lecturas.Entidades.ProgresoLecturas> ListaProgreso { get; set; } = new();

        [BindProperty]
        public int PaginasLeidas { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Libro = _negocio.Consultar().FirstOrDefault(l => l.Id == id)!;
            if (Libro == null) return NotFound();

            if (User.Identity!.IsAuthenticated)
            {
                var identityUser = await _userManager.GetUserAsync(User);
                var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);

                if (usuarioDb != null)
                {
                    HistorialActual = _context.HistorialLecturas
                        .FirstOrDefault(h => h.UsuarioId == usuarioDb.Id && h.LibroId == id && h.FechaFin == null);

                    // Lectura activa
                    LecturaActual = _context.Lecturas
                        .FirstOrDefault(l => l.UsuarioId == usuarioDb.Id && l.LibroId == id && !l.Estado);

                    // Progreso de la lectura actual
                    if (LecturaActual != null)
                    {
                        ListaProgreso = _context.ProgresoLecturas
                            .Where(p => p.LecturaId == LecturaActual.Id)
                            .OrderByDescending(p => p.FechaActualizacion)
                            .ToList();
                    }
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Libro = _negocio.Consultar().FirstOrDefault(l => l.Id == id)!;

            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);

            if (usuarioDb == null) return RedirectToPage("/Account/Login");

            // Buscar o crear Lectura
            var lectura = _context.Lecturas
                .FirstOrDefault(l => l.UsuarioId == usuarioDb.Id && l.LibroId == id && !l.Estado);

            if (lectura == null)
            {
                lectura = new Libreria_Lecturas.Entidades.Lecturas
                {
                    UsuarioId = usuarioDb.Id,
                    LibroId = id,
                    FechaInicio = DateTime.Now,
                    Estado = false
                };
                _context.Lecturas.Add(lectura);
                await _context.SaveChangesAsync();
            }

            // Registrar progreso
            var progreso = new Libreria_Lecturas.Entidades.ProgresoLecturas
            {
                LecturaId = lectura.Id,
                PaginasLeidas = PaginasLeidas,
                FechaActualizacion = DateTime.Now
            };
            progreso.CalcularPorcentaje(Libro.PaginasTotales);
            _context.ProgresoLecturas.Add(progreso);

            // Si terminó el libro
            if (PaginasLeidas >= Libro.PaginasTotales)
            {
                lectura.Estado = true;
                lectura.FechaFin = DateTime.Now;
                _context.Lecturas.Update(lectura);
            }

            // Actualizar historial
            var historial = _context.HistorialLecturas
                .FirstOrDefault(h => h.UsuarioId == usuarioDb.Id && h.LibroId == id && h.FechaFin == null);

            if (historial == null)
            {
                _context.HistorialLecturas.Add(new Libreria_Lecturas.Entidades.HistorialLecturas
                {
                    UsuarioId = usuarioDb.Id,
                    LibroId = id,
                    FechaInicio = DateTime.Now,
                    PaginasLeidas = PaginasLeidas
                });
            }
            else
            {
                historial.PaginasLeidas = PaginasLeidas;
                if (PaginasLeidas >= Libro.PaginasTotales)
                    historial.FechaFin = DateTime.Now;
                _context.HistorialLecturas.Update(historial);
            }

            await _context.SaveChangesAsync();

            // Recalcular estadísticas
            var totalHistorial = _context.HistorialLecturas
                .Where(h => h.UsuarioId == usuarioDb.Id).ToList();

            var librosLeidos = totalHistorial
                .Where(h => h.LibroId.HasValue)
                .Select(h => h.LibroId).Distinct().Count();

            var paginasTotales = totalHistorial.Sum(h => h.PaginasLeidas ?? 0);
            var promedio = librosLeidos > 0 ? (decimal)paginasTotales / librosLeidos : 0;

            var estadistica = _context.Estadisticas
                .FirstOrDefault(e => e.UsuarioId == usuarioDb.Id);

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

            return RedirectToPage("/Libros/Detalle", new { id });
        }

        public IActionResult OnGetDescargarPDF(int id)
        {
            Libro = _negocio.Consultar().FirstOrDefault(l => l.Id == id)!;
            if (Libro == null) return NotFound();

            var pdf = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(50);
                    page.DefaultTextStyle(x => x.FontSize(12).FontFamily("Georgia"));

                    page.Content().Column(col =>
                    {
                        col.Item().Text(Libro.Titulo ?? "")
                            .FontSize(24).Bold().FontColor("#3d2b1a");

                        col.Item().PaddingTop(8).Text($"— {Libro.Autor} —")
                            .FontSize(14).Italic().FontColor("#8b6340");

                        col.Item().PaddingTop(20).Text($"Páginas: {Libro.PaginasTotales}")
                            .FontSize(12).FontColor("#5a3e28");

                        col.Item().PaddingTop(4).Text($"Año: {(Libro.AnoPublicacion.HasValue ? Libro.AnoPublicacion.Value.Year.ToString() : "No disponible")}")
                            .FontSize(12).FontColor("#5a3e28");

                        col.Item().PaddingTop(24).Text("Sinopsis")
                            .FontSize(14).Bold().FontColor("#8b6340");

                        col.Item().PaddingTop(8).Text(Libro.Sinopsis ?? "Sin sinopsis disponible.")
                            .FontSize(12).FontColor("#3d2b1a").LineHeight(1.8f);

                        col.Item().PaddingTop(40).Text("LecturasWeb")
                            .FontSize(10).FontColor("#aaaaaa").AlignCenter();
                    });
                });
            });

            var stream = new MemoryStream();
            pdf.GeneratePdf(stream);
            stream.Position = 0;

            return File(stream, "application/pdf", $"{Libro.Titulo}.pdf");
        }
    }
}