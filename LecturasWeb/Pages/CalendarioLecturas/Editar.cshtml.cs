using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LecturasWeb.Pages.CalendarioLecturas_Pages
{
    public class EditarModel : PageModel
    {
        private readonly ICalendarioLecturasNegocio _negocio;
        private readonly Conexion _context;

        public EditarModel(ICalendarioLecturasNegocio negocio, Conexion context)
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
            if (!ModelState.IsValid) return Page();
            _negocio.Modificar(Calendario);
            AuditoriaHelper.Registrar(_context, "Calendaria", "Editar", User.Identity?.Name ?? "sistema", $"Calendario creado: \"{Calendario}\"");
            return RedirectToPage("/CalendarioLecturas");
        }
    }
}