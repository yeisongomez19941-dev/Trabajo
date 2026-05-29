using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Notificaciones
{
    public class EliminarModel : PageModel
    {
        private readonly INotificacionesNegocio _negocio;
        private readonly Conexion _context;

        public EliminarModel(INotificacionesNegocio negocio, Conexion context)
        {
            _negocio = negocio;
            _context = context;
        }
        [BindProperty]
        public Libreria_Lecturas.Entidades.Notificaciones Notificaciones { get; set; } = new();

        public List<Libreria_Lecturas.Entidades.Usuarios> ListaUsuarios { get; set; } = new();
        public IActionResult OnGet(int id)
        {
            Notificaciones = _negocio.Consultar().FirstOrDefault(n => n.Id == id)!;
            if (Notificaciones == null) return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            _negocio.Borrar(Notificaciones);
            return RedirectToPage("/Notificaciones");
        }
    }
}


