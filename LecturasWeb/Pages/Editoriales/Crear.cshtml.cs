using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Editoriales
{
    public class CrearModel : PageModel
    {
        private readonly IEditorialesNegocio _negocio;
        private readonly IAuditoriasNegocio _auditorias;

        public CrearModel(IEditorialesNegocio negocio, IAuditoriasNegocio auditorias)
        {
            _negocio = negocio;
            _auditorias = auditorias;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Editoriales Editoriales{ get; set; } = new();
        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Editoriales);
            _auditorias.Registrar("Editoriales", "Crear",
                User.Identity?.Name ?? "Sistema",
                $"Editorial creada: {Editoriales.Nombre}");
            return RedirectToPage("/Editoriales");
        }
    }
}
