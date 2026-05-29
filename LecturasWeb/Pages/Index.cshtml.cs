using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Libreria_Lecturas.Implementaciones;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LecturasWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILibrosNegocio _librosNegocio;
        private readonly IFavoritosNegocio _favoritosNegocio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Conexion _context;

        public IndexModel(
            ILibrosNegocio librosNegocio,
            IFavoritosNegocio favoritosNegocio,
            UserManager<IdentityUser> userManager,
            Conexion context)
        {
            _librosNegocio = librosNegocio;
            _favoritosNegocio = favoritosNegocio;
            _userManager = userManager;
            _context = context;
        }

        public List<Libreria_Lecturas.Entidades.Libros> LibrosDestacados { get; set; } = new();
        public List<Libreria_Lecturas.Entidades.Libros> LibrosMasLeidos { get; set; } = new();
        public List<Libreria_Lecturas.Entidades.Libros> LibrosRecomendados { get; set; } = new();
        public HashSet<int> LibrosFavoritos { get; set; } = new();

        public async Task OnGetAsync()
        {
            // Novedades → más recientes
            LibrosDestacados = _context.Libros
                .Include(l => l._GeneroId)
                .OrderByDescending(l => l.AnoPublicacion)
                .Take(6).ToList();

            // Más leídos → más veces en historial
            LibrosMasLeidos = _context.Libros
                .Include(l => l._GeneroId)
                .Include(l => l._Lecturas)
                .OrderByDescending(l => l._Lecturas!.Count)
                .Take(6).ToList();

            // Recomendados → más favoritos
            LibrosRecomendados = _context.Libros
                .Include(l => l._GeneroId)
                .Include(l => l._Favoritos)
                .OrderByDescending(l => l._Favoritos!.Count)
                .Take(6).ToList();

            if (User.Identity!.IsAuthenticated)
            {
                var identityUser = await _userManager.GetUserAsync(User);
                var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);

                if (usuarioDb == null)
                {
                    usuarioDb = new Libreria_Lecturas.Entidades.Usuarios
                    {
                        Nombre = identityUser!.UserName ?? "Usuario",
                        Email = identityUser.Email!,
                        FechaRegistro = DateTime.UtcNow
                    };
                    _context.Usuarios.Add(usuarioDb);
                    await _context.SaveChangesAsync();
                }

                LibrosFavoritos = _favoritosNegocio.Consultar(usuarioDb.Id)
                    .Where(f => f.LibroId.HasValue)
                    .Select(f => f.LibroId!.Value)
                    .ToHashSet();
            }
        }

        public async Task<IActionResult> OnPostToggleFavoritoAsync(int libroId)
        {
            if (!User.Identity!.IsAuthenticated)
                return RedirectToPage("/Account/Login");

            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);

            if (usuarioDb == null)
            {
                usuarioDb = new Libreria_Lecturas.Entidades.Usuarios
                {
                    Nombre = identityUser!.UserName ?? "Usuario",
                    Email = identityUser.Email!,
                    FechaRegistro = DateTime.UtcNow
                };
                _context.Usuarios.Add(usuarioDb);
                await _context.SaveChangesAsync();
            }

            var existente = _favoritosNegocio.Consultar(usuarioDb.Id)
                .FirstOrDefault(f => f.LibroId == libroId);

            if (existente != null)
                _favoritosNegocio.Borrar(existente);
            else
                _favoritosNegocio.Guardar(new Libreria_Lecturas.Entidades.Favoritos
                {
                    LibroId = libroId,
                    UsuarioId = usuarioDb.Id,
                    FechaMarcado = DateTime.UtcNow,
                    Activo = true
                });

            return RedirectToPage();
        }
    }
}