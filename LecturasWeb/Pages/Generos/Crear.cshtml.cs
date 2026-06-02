using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Generos
{
    public class CrearModel : PageModel
    {
        private readonly IGenerosNegocio _negocio;
        private readonly IAuditoriasNegocio _auditorias;

        public CrearModel(IGenerosNegocio negocio, IAuditoriasNegocio auditorias)
        {
            _negocio = negocio;
            _auditorias = auditorias;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Generos Generos { get; set; } = new();
      

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Generos);
            _auditorias.Registrar("Generos", "Crear",
                User.Identity?.Name ?? "Sistema",
                $"Genero creado: {Generos.Nombre}");
            return RedirectToPage("/Generos");
        }
    }
}

