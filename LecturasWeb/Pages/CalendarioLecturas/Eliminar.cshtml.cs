using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LecturasWeb.Pages.CalendarioLecturas_Pages
{
    public class EliminarModel : PageModel
    {
        private readonly ICalendarioLecturasNegocio _negocio;
        private readonly Conexion _context;

        public EliminarModel(ICalendarioLecturasNegocio negocio, Conexion context)
        {
            _negocio = negocio;
            _context = context;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.CalendarioLecturas Calendario { get; set; } = new();

        public void OnGet(int id)
        {
            Calendario = _negocio.Consultar().FirstOrDefault(c => c.Id == id)!;
        }

        public IActionResult OnPost()
        {
            _negocio.Borrar(Calendario);
            
            AuditoriaHelper.Registrar(_context, "Calendario", "Eliminar", User.Identity?.Name ?? "sistema", $"Calendario eliminado: \"{Calendario}\"");
            return RedirectToPage("/CalendarioLecturas");
        }
    }
}