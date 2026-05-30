using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Libreria_Lecturas.Implementaciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Autores_Pages
{
    public class EditarModel : PageModel
    {
        private readonly IAutoresNegocio _negocio;
        private readonly Conexion _context;

        public EditarModel(IAutoresNegocio negocio, Conexion context)
        {
            _negocio = negocio;
            _context = context;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Autores Autor { get; set; } = new();

        public void OnGet(int id)
        {
            Autor = _negocio.Consultar().FirstOrDefault(a => a.Id == id)!;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Autor);
            AuditoriaHelper.Registrar(_context, "Autores", "Editar", User.Identity?.Name ?? "sistema", $"Autor editado: \"{Autor.Nombre}\"");
            return RedirectToPage("/Autores");
        }
    }
}