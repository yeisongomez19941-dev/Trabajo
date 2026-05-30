using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Autores_Pages  
{
    public class CrearModel : PageModel
    {
        private readonly IAutoresNegocio _negocio;
        private readonly Conexion _context; 

        public CrearModel(IAutoresNegocio negocio, Conexion context)
        {
            _negocio = negocio;
            _context = context;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Autores Autor { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Autor);
            AuditoriaHelper.Registrar(_context, "Autores", "Crear", User.Identity?.Name ?? "sistema", $"Autor creado: \"{Autor.Nombre}\"");
            return RedirectToPage("/Autores");
         
        }
    }
}