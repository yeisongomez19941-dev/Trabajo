using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Autores_Pages
{
    public class EliminarModel : PageModel
    {
        private readonly IAutoresNegocio _negocio;
        private readonly Conexion _context;

        public EliminarModel(IAutoresNegocio negocio, Conexion context)
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
            _negocio.Borrar(Autor);
            AuditoriaHelper.Registrar(_context, "Autores", "Eliminar", User.Identity?.Name ?? "sistema", $"Autor eliminado: \"{Autor.Nombre}\"");
            return RedirectToPage("/Autores");
        }
    }
}