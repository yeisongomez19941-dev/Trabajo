using Libreria_Lecturas.Interfaces;
using Libreria_Lecturas.Implementaciones; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LecturasWeb.Pages.Editoriales
{
    public class EliminarModel : PageModel
    {
        private readonly IEditorialesNegocio _negocio;
        private readonly Conexion _context;

        public EliminarModel(IEditorialesNegocio negocio, Conexion context)
        {
            _negocio = negocio;
            _context = context;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Editoriales Editoriales { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Editoriales = _negocio.Consultar().FirstOrDefault(l => l.Id == id)!;
            if (Editoriales == null) return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            AuditoriaHelper.Registrar(_context, "Editoriales", "Eliminar", User.Identity?.Name ?? "sistema", $"Editorial eliminada: \"{Editoriales.Nombre}\"");
            _negocio.Borrar(Editoriales);
            return RedirectToPage("/Editoriales");
        }
    }
}



