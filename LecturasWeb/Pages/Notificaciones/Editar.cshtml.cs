using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Notificaciones
{
    public class EditarModel : PageModel
    {
        private readonly INotificacionesNegocio _negocio;
        private readonly Conexion _context;

        public EditarModel(INotificacionesNegocio negocio, Conexion context)
        {
            _negocio = negocio;
            _context = context;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Notificaciones Notificaciones { get; set; } = new();

        public List<Libreria_Lecturas.Entidades.Usuarios> ListaUsuarios { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Notificaciones = _context.Notificaciones.FirstOrDefault(n => n.Id == id)!;
            if (Notificaciones == null) return RedirectToPage("/Notificaciones");

            ListaUsuarios = _context.Usuarios.ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Modificar(Notificaciones);
            return RedirectToPage("/Notificaciones");
        }
    }
}