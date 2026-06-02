using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Estadisticas
{

    public class CrearModel : PageModel
    {
        private readonly IEstadisticasNegocio _negocio;
        private readonly IAuditoriasNegocio _auditorias;

        public CrearModel(IEstadisticasNegocio negocio, IAuditoriasNegocio auditorias)
        {
            _negocio = negocio;
            _auditorias = auditorias;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Estadisticas Estadisticas{ get; set; } = new();
        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Estadisticas);
            _auditorias.Registrar("Estadisticas", "Crear",
                User.Identity?.Name ?? "Sistema",
                $"Estadistica creada: {Estadisticas.UsuarioId}");
            return RedirectToPage("/Estadisticas");
        }
    }
}



