using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages
{
    public class NotificacionesModel : PageModel
    {
        private readonly INotificacionesNegocio _negocio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Conexion _context;

        public NotificacionesModel(
            INotificacionesNegocio negocio,
            UserManager<IdentityUser> userManager,
            Conexion context)
        {
            _negocio = negocio;
            _userManager = userManager;
            _context = context;
        }

        public List<Libreria_Lecturas.Entidades.Notificaciones> ListaNotificaciones { get; set; } = new();
        public int NoLeidas { get; set; }

        public async Task OnGetAsync()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);

            if (usuarioDb != null)
            {
                ListaNotificaciones = _context.Notificaciones
                    .Where(n => n.UsuarioId == usuarioDb.Id)
                    .OrderByDescending(n => n.FechaEnvio)
                    .ToList();

                NoLeidas = ListaNotificaciones.Count(n => n.Leida == false);
            }
        }

        public async Task<IActionResult> OnPostMarcarLeidaAsync(int id)
        {
            var notificacion = _context.Notificaciones.FirstOrDefault(n => n.Id == id);
            if (notificacion != null)
            {
                notificacion.Leida = true;
                _context.Notificaciones.Update(notificacion);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}