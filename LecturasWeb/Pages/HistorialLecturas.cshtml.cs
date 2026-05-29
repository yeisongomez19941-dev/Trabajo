using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LecturasWeb.Pages
{
    public class HistorialLecturasModel : PageModel
    {
        private readonly IHistorialLecturasNegocio _negocio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Conexion _context;

        public HistorialLecturasModel(
            IHistorialLecturasNegocio negocio,
            UserManager<IdentityUser> userManager,
            Conexion context)
        {
            _negocio = negocio;
            _userManager = userManager;
            _context = context;
        }

        public List<Libreria_Lecturas.Entidades.HistorialLecturas> ListaHistorial { get; set; } = new();

        public async Task OnGetAsync()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);

            if (usuarioDb != null)
            {
                // Cada usuario solo ve su propio historial
                ListaHistorial = await _context.HistorialLecturas
                    .Include(h => h._LibroId)
                    .Where(h => h.UsuarioId == usuarioDb.Id)
                    .OrderByDescending(h => h.FechaInicio)
                    .ToListAsync();
            }
        }
    }
}